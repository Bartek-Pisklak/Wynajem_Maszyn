using Microsoft.AspNetCore.Components.Forms;

namespace WynajemMaszyn.WebUI.Components.Pages.Form
{
    public class FileUploud
    {
        private readonly string _baseFolderPath;
        private const long MaxFileSize = 5 * 1024 * 1024; // 5 MB

        public FileUploud(string baseFolderPath = "wwwroot/uploads")
        {
            _baseFolderPath = baseFolderPath;

            if (!Directory.Exists(_baseFolderPath))
            {
                Directory.CreateDirectory(_baseFolderPath);
            }
        }


        /// <summary>
        /// Zapisuje przesłany plik i zwraca ścieżkę do zapisu w bazie danych.
        /// </summary>
        /// <param name="uploadedFile">Przesłany plik</param>
        /// <returns>Relatywna ścieżka pliku do zapisu w bazie danych</returns>
        public async Task<string> CreatePathToImage(IBrowserFile? uploadedFile)
        {

            if (uploadedFile is null)
            {
                return null;
            }
            try
            {
                // generowanie nazwy i ścieżki do pliku
                var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(uploadedFile.Name)}";
                var fullPath = Path.Combine(_baseFolderPath, uniqueFileName);

                // Otwieranie strumienia z ograniczeniem rozmiaru
                await using var fileStream = new FileStream(fullPath, FileMode.Create);
                await uploadedFile.OpenReadStream(MaxFileSize).CopyToAsync(fileStream);

                // Generowanie relatywnej ścieżki do pliku
                var databaseFilePath = Path.Combine("uploads", uniqueFileName).Replace("\\", "/");
                return databaseFilePath;

            }
            catch (Exception ex)
            {
                // Logowanie błędu (możesz użyć loggera)
                Console.WriteLine($"Błąd podczas zapisywania pliku: {ex.Message}");
                return null;
            }
        }

        public bool DeleteImage(string? imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                Console.WriteLine("Ścieżka do pliku jest pusta.");
                return false;
            }

            try
            {
                // Tworzenie pełnej ścieżki do pliku
                var fullPath = Path.Combine(_baseFolderPath, imagePath);

                // Sprawdzenie, czy plik istnieje
                if (File.Exists(fullPath))
                {
                    // Usuwanie pliku
                    File.Delete(fullPath);
                    Console.WriteLine($"Plik został usunięty: {fullPath}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Plik nie istnieje: {fullPath}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Logowanie błędu
                Console.WriteLine($"Błąd podczas usuwania pliku: {ex.Message}");
                return false;
            }
        }

    }
}
