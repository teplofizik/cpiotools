﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NyaFsTest
{
    static class ImportExportText
    {
        static void TestImportNative()
        {
            var Dir = "example\\";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.NativeReader(Dir, 0, 0, 0x744, 0x755);
            Importer.ReadToFs(Fs);

            Fs.Dump();
        }

        static void TestImportCpio()
        {
            var Fn = "example.cpio";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.CpioReader(Fn);
            Importer.ReadToFs(Fs);

            Fs.Dump();
        }

        static void TestImportRamFsExt4()
        {
            var Fn = "legacy.bin";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.LegacyFsReader(Fn);
            Importer.ReadToFs(Fs);

            Fs.Dump();
        }

        static void TestImportRamFsCpio()
        {
            var Fn = "legacy.bin";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.LegacyFsReader(Fn);
            Importer.ReadToFs(Fs);

            Fs.Dump();
        }
        static void TestImportRamFsCpioExportNative()
        {
            var Fn = "legacy.bin";
            var Dst = "extracted\\";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.LegacyFsReader(Fn);
            Importer.ReadToFs(Fs);

            Fs.Dump();

            var Exporter = new NyaFs.ImageFormat.Fs.Writer.NativeWriter(Dst);
            Exporter.WriteFs(Fs);
        }
        static void TestImportRamFsCpioExportCpio()
        {
            var Fn = "initramfs.bin";
            var Dst = "extracted.cpio";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.LegacyFsReader(Fn);
            Importer.ReadToFs(Fs);

            Fs.Dump();

            var Exporter = new NyaFs.ImageFormat.Fs.Writer.CpioWriter(Dst);
            Exporter.WriteFs(Fs);
        }
        static void TestImportRamFsCpioExportGzCpio()
        {
            var Fn = "legacy.bin";
            var Dst = "extracted.gz";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.LegacyFsReader(Fn);
            Importer.ReadToFs(Fs);

            Fs.Dump();

            var Exporter = new NyaFs.ImageFormat.Fs.Writer.GzCpioWriter(Dst);
            Exporter.WriteFs(Fs);
        }

        static void TestImportRamFsCpioExportRamFsCpio()
        {
            var Fn = "legacy.bin";
            var Dst = "legacy.bin.saved";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.LegacyFsReader(Fn);
            Importer.ReadToFs(Fs);

            Fs.Dump();

            var Exporter = new NyaFs.ImageFormat.Fs.Writer.LegacyFsWriter(Dst);
            Exporter.WriteFs(Fs);
        }
    }
}