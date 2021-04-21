﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using TesseractSharp.Core;

namespace TesseractSharp
{
    public static class Tesseract
    {
        public static Stream ImageToPdf(
            string inputFilePath,
            long? dotPerInch = null,
            PageSegMode? psm = null,
            OcrEngineMode? oem = null,
            IEnumerable<Language> languages = null,
            IEnumerable<KeyValuePair<string, string>> configVars = null
        )
        {
            var outputBasenameFilePath = Path.Combine(Path.GetTempPath(), "tess_" + Guid.NewGuid().ToString("N"));
            var configFiles = new List<ConfigFile>{ConfigFile.OutputPdf};

            TesseractEngine engine;
            try
            {
                engine = new TesseractEngine(
                    inputFilePath, outputBasenameFilePath,
                    dotPerInch, psm, oem, languages,
                    configFiles, configVars);

            }
            catch (Exception ex)
            {
                throw new TesseractException("Fail to call tesseract", ex);
            }

            if (engine.Result.ExitCode != 0)
                throw new TesseractException(engine.Result.Error);

            var outputFilePath = outputBasenameFilePath + ".pdf";

            if (!File.Exists(outputFilePath))
                throw new TesseractException("PDF was not generated.");

            return new BurnAfterReadingFileStream(outputFilePath);
        }

        public static Stream ImageToPdf(
            Bitmap bitmap,
            long? dotPerInch = null,
            PageSegMode? psm = null,
            OcrEngineMode? oem = null,
            IEnumerable<Language> languages = null,
            IEnumerable<KeyValuePair<string, string>> configVars = null
        )
        {
            var inputBasenameFilePath = Path.Combine(Path.GetTempPath(), "tess_" + Guid.NewGuid().ToString("N") + ".png");
            try
            {
                bitmap.Save(inputBasenameFilePath, ImageFormat.Png);
                return ImageToPdf(inputBasenameFilePath, dotPerInch, psm, oem, languages, configVars);
            }
            finally
            {
                if (File.Exists(inputBasenameFilePath))
                    File.Delete(inputBasenameFilePath);
            }
        }

        public static Stream ImageToTxt(
            string inputFilePath,
            long? dotPerInch = null,
            PageSegMode? psm = null,
            OcrEngineMode? oem = null,
            IEnumerable<Language> languages = null,
            IEnumerable<KeyValuePair<string, string>> configVars = null
        )
        {
            var outputBasenameFilePath = "stdout";
            var configFiles = new List<ConfigFile> { ConfigFile.OutputTxt };

            TesseractEngine engine;
            try
            {
                engine = new TesseractEngine(
                    inputFilePath, outputBasenameFilePath,
                    dotPerInch, psm, oem, languages,
                    configFiles, configVars);

            }
            catch (Exception ex)
            {
                throw new TesseractException("Fail to call tesseract", ex);
            }

            if (engine.Result.ExitCode != 0)
                throw new InvalidOperationException(engine.Result.Error);

            return new MemoryStream(Encoding.UTF8.GetBytes(engine.Result.Output));
        }

        public static Stream ImageToTxt(
            Bitmap bitmap,
            long? dotPerInch = null,
            PageSegMode? psm = null,
            OcrEngineMode? oem = null,
            IEnumerable<Language> languages = null,
            IEnumerable<KeyValuePair<string, string>> configVars = null
        )
        {
            var inputBasenameFilePath = Path.Combine(Path.GetTempPath(), "tess_" + Guid.NewGuid().ToString("N") + ".png");
            try
            {
                bitmap.Save(inputBasenameFilePath, ImageFormat.Png);
                return ImageToTxt(inputBasenameFilePath, dotPerInch, psm, oem, languages, configVars);
            }
            finally
            {
                if (File.Exists(inputBasenameFilePath))
                    File.Delete(inputBasenameFilePath);
            }
        }

        public static Stream ImageToTsv(
            string inputFilePath,
            long? dotPerInch = null,
            PageSegMode? psm = null,
            OcrEngineMode? oem = null,
            IEnumerable<Language> languages = null,
            IEnumerable<KeyValuePair<string, string>> configVars = null
        )
        {
            var outputBasenameFilePath = "stdout";
            var configFiles = new List<ConfigFile> { ConfigFile.OutputTsv };

            TesseractEngine engine;
            try
            {
                engine = new TesseractEngine(
                    inputFilePath, outputBasenameFilePath,
                    dotPerInch, psm, oem, languages,
                    configFiles, configVars);

            }
            catch (Exception ex)
            {
                throw new TesseractException("Fail to call tesseract", ex);
            }

            return new MemoryStream(Encoding.UTF8.GetBytes(engine.Result.Output));
        }

        public static Stream ImageToTsv(
            Bitmap bitmap,
            long? dotPerInch = null,
            PageSegMode? psm = null,
            OcrEngineMode? oem = null,
            IEnumerable<Language> languages = null,
            IEnumerable<KeyValuePair<string, string>> configVars = null
        )
        {
            var inputBasenameFilePath = Path.Combine(Path.GetTempPath(), "tess_" + Guid.NewGuid().ToString("N") + ".png");
            try
            {
                bitmap.Save(inputBasenameFilePath, ImageFormat.Png);
                return ImageToTsv(inputBasenameFilePath, dotPerInch, psm, oem, languages, configVars);
            }
            finally
            {
                if (File.Exists(inputBasenameFilePath))
                    File.Delete(inputBasenameFilePath);
            }
        }

        public static Stream ImageToHocr(
            string inputFilePath,
            long? dotPerInch = null,
            PageSegMode? psm = null,
            OcrEngineMode? oem = null,
            IEnumerable<Language> languages = null,
            IEnumerable<KeyValuePair<string, string>> configVars = null
        )
        {
            var outputBasenameFilePath = "stdout";
            var configFiles = new List<ConfigFile> { ConfigFile.OutputHocr };

            TesseractEngine engine;
            try
            {
                engine = new TesseractEngine(
                    inputFilePath, outputBasenameFilePath,
                    dotPerInch, psm, oem, languages,
                    configFiles, configVars);

            }
            catch (Exception ex)
            {
                throw new TesseractException("Fail to call tesseract", ex);
            }

            return new MemoryStream(Encoding.UTF8.GetBytes(engine.Result.Output));
        }

        public static Stream ImageToHocr(
            Bitmap bitmap,
            long? dotPerInch = null,
            PageSegMode? psm = null,
            OcrEngineMode? oem = null,
            IEnumerable<Language> languages = null,
            IEnumerable<KeyValuePair<string, string>> configVars = null
        )
        {
            var inputBasenameFilePath = Path.Combine(Path.GetTempPath(), "tess_" + Guid.NewGuid().ToString("N") + ".png");
            try
            {
                bitmap.Save(inputBasenameFilePath, ImageFormat.Png);
                return ImageToHocr(inputBasenameFilePath, dotPerInch, psm, oem, languages, configVars);
            }
            finally
            {
                if (File.Exists(inputBasenameFilePath))
                    File.Delete(inputBasenameFilePath);
            }
        }

        public static Stream ImageToAlto(
            string inputFilePath,
            long? dotPerInch = null,
            PageSegMode? psm = null,
            OcrEngineMode? oem = null,
            IEnumerable<Language> languages = null,
            IEnumerable<KeyValuePair<string, string>> configVars = null
        )
        {
            var outputBasenameFilePath = "stdout";
            var configFiles = new List<ConfigFile> { ConfigFile.OutputAlto };

            TesseractEngine engine;
            try
            {
                engine = new TesseractEngine(
                    inputFilePath, outputBasenameFilePath,
                    dotPerInch, psm, oem, languages,
                    configFiles, configVars);

            }
            catch (Exception ex)
            {
                throw new TesseractException("Fail to call tesseract", ex);
            }

            return new MemoryStream(Encoding.UTF8.GetBytes(engine.Result.Output));
        }

        public static Stream ImageToAlto(
            Bitmap bitmap,
            long? dotPerInch = null,
            PageSegMode? psm = null,
            OcrEngineMode? oem = null,
            IEnumerable<Language> languages = null,
            IEnumerable<KeyValuePair<string, string>> configVars = null
        )
        {
            var inputBasenameFilePath = Path.Combine(Path.GetTempPath(), "tess_" + Guid.NewGuid().ToString("N") + ".png");
            try
            {
                bitmap.Save(inputBasenameFilePath, ImageFormat.Png);
                return ImageToAlto(inputBasenameFilePath, dotPerInch, psm, oem, languages, configVars);
            }
            finally
            {
                if (File.Exists(inputBasenameFilePath))
                    File.Delete(inputBasenameFilePath);
            }
        }
    }
}
