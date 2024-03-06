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
        internal readonly string _url = "general/v0/general";

        /// <summary>
        /// Client for interacting with the Unstructured API.
        /// </summary>
        public UnstructuredClient(string url, string? apiKey = null)
        {
            _client = SetupClient(url, apiKey);
        }

        private HttpClient SetupClient(string url, string? apiKey)
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
            try
            {
                using var formContent = new MultipartFormDataContent();
                ParametersHelper.AddFileFromPath(formContent, filePath);
                return await ExecutePartitionRequest(formContent, cancellationToken);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        /// <inheritdoc/>
        public async Task<ApiResponse> PartitionAsync(string filePath, ExtractionOptions options, CancellationToken cancellationToken)
        {
            try
            {
                using var formContent = new MultipartFormDataContent();
                ParametersHelper.AddFileFromPath(formContent, filePath);
                ParametersHelper.AddMappedParameters(formContent, options);
                return await ExecutePartitionRequest(formContent, cancellationToken);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> PartitionAsync(Stream fileStream, string fileName, CancellationToken cancellationToken)
        {
            try
            {
                using var formContent = new MultipartFormDataContent();
                ParametersHelper.AddFileFromStream(formContent, fileStream, fileName);
                return await ExecutePartitionRequest(formContent, cancellationToken);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> PartitionAsync(Stream fileStream, string fileName, ExtractionOptions options, CancellationToken cancellationToken)
        {
            try
            {
                using var formContent = new MultipartFormDataContent();
                ParametersHelper.AddFileFromStream(formContent, fileStream, fileName);
                ParametersHelper.AddMappedParameters(formContent, options);
                return await ExecutePartitionRequest(formContent, cancellationToken);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        private async Task<ApiResponse> ExecutePartitionRequest(MultipartFormDataContent formContent, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _client.PostAsync(_url, formContent, cancellationToken);
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
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        private T DeserializeResponse<T>(string content)
        {
            return JsonSerializer.Deserialize<T>(content)!;
        }

        private ApiResponse HandleException(Exception ex)
        {
            return new ApiResponse
            {
                Message = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }
}
