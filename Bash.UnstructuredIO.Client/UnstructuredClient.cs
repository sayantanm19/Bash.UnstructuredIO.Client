using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using UnstructuredAPI.Interfaces;
using UnstructuredAPI.Models;
using UnstructuredAPI.Services;

namespace UnstructuredAPI
{
    public class UnstructuredClient : IUnstructuredClient
    {
        internal readonly HttpClient _client;

        /// <summary>
        /// Client for interacting with the Unstructured API.
        /// </summary>
        public UnstructuredClient(string url)
        {
            _client = SetupClient(url);
        }

        public UnstructuredClient(string url, string apiKey = null)
        {
            _client = SetupClient(url, apiKey);
        }

        private HttpClient SetupClient(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "multipart/form-data");

            return client;
        }

        private HttpClient SetupClient(string url, string apiKey)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "multipart/form-data");

            if (!string.IsNullOrEmpty(apiKey))
                client.DefaultRequestHeaders.Add("unstructured-api-key", apiKey);

            return client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> PartitionAsync(string filePath, CancellationToken cancellationToken)
        {
            var formContent = new MultipartFormDataContent();
            ParametersHelper.AddFileFromPath(formContent, filePath);
            return await ExecutePartitionRequest(formContent, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> PartitionAsync(string filePath, ExtractionOptions options, CancellationToken cancellationToken)
        {
            using var formContent = new MultipartFormDataContent();
            ParametersHelper.AddFileFromPath(formContent, filePath);
            ParametersHelper.AddMappedParameters(formContent, options);
            return await ExecutePartitionRequest(formContent, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> PartitionAsync(Stream fileStream, string fileName, CancellationToken cancellationToken)
        {
            using var formContent = new MultipartFormDataContent();
            ParametersHelper.AddFileFromStream(formContent, fileStream, fileName);
            return await ExecutePartitionRequest(formContent, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> PartitionAsync(Stream fileStream, string fileName, ExtractionOptions options, CancellationToken cancellationToken)
        {
            using var formContent = new MultipartFormDataContent();
            ParametersHelper.AddFileFromStream(formContent, fileStream, fileName);
            ParametersHelper.AddMappedParameters(formContent, options);
            return await ExecutePartitionRequest(formContent, cancellationToken);
        }
        private async Task<ApiResponse> ExecutePartitionRequest(MultipartFormDataContent formContent, CancellationToken cancellationToken)
        {
            var response = await _client.PostAsync("general/v0/general", formContent, cancellationToken);
            var contents = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var deserializedElements = DeserializeResponse<List<Element>>(contents);
                return new ApiResponse
                {
                    Data = deserializedElements,
                    StatusCode = HttpStatusCode.OK
                };
            }
            else
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var deserializeError = DeserializeResponse<ErrorDetail>(contents!);
                    return new ApiResponse
                    {
                        Message = deserializeError,
                        StatusCode = HttpStatusCode.Unauthorized
                    };
                }
                else
                {
                    var deserializeError = DeserializeResponse<ErrorDetails>(contents!);
                    return new ApiResponse
                    {
                        Message = deserializeError,
                        StatusCode = response.StatusCode
                    };
                }
            }
        }
        private T DeserializeResponse<T>(string content)
        {
            return JsonSerializer.Deserialize<T>(content)!;
        }
    }
}
