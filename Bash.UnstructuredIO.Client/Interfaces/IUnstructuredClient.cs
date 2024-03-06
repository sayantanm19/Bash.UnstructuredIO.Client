using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnstructuredAPI.Models;

namespace UnstructuredAPI.Interfaces
{
    public interface IUnstructuredClient
    {
        /// <summary>
        /// Asynchronously partitions the file specified by its file path.
        /// </summary>
        /// <param name="filePath">The path to the file to be partitioned.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, yielding an <see cref="ApiResponse"/>.</returns>
        Task<ApiResponse> PartitionAsync(string filePath, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously partitions the file specified by its file path with additional extraction options.
        /// </summary>
        /// <param name="filePath">The path to the file to be partitioned.</param>
        /// <param name="options">Additional options for the partitioning process.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, yielding an <see cref="ApiResponse"/>.</returns>
        Task<ApiResponse> PartitionAsync(string filePath, ExtractionOptions options, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously partitions the file specified by its stream.
        /// </summary>
        /// <param name="fileStream">The stream containing the file data to be partitioned.</param>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, yielding an <see cref="ApiResponse"/>.</returns>
        Task<ApiResponse> PartitionAsync(Stream fileStream, string fileName, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously partitions the file specified by its stream with additional extraction options.
        /// </summary>
        /// <param name="fileStream">The stream containing the file data to be partitioned.</param>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="options">Additional options for the partitioning process.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, yielding an <see cref="ApiResponse"/>.</returns>
        Task<ApiResponse> PartitionAsync(Stream fileStream, string fileName, ExtractionOptions options, CancellationToken cancellationToken);

    }
}