﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NyaFsTest
{
    static class ImportExportText
    {
        static void TestImportNative()
        {
            var Dir = "F:\\Проекты\\Асик конфиг\\cpiotools\\InitramfsTool\\bin\\Debug\\netcoreapp3.1\\a113d\\full";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.NativeReader(Dir, 0, 0, 0x744, 0x755);
            Importer.ReadToFs(Fs);

            Fs.Dump();
        }

        static void TestImportCpio()
        {
            var Fn = "F:\\Проекты\\Асик конфиг\\cpiotools\\InitramfsTool\\bin\\Debug\\netcoreapp3.1\\a113d\\s19xp_ramfs.cpio";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.CpioReader(Fn);
            Importer.ReadToFs(Fs);

            Fs.Dump();
        }

        static void TestImportRamFsExt4()
        {
            var Fn = "F:\\Проекты\\Асик конфиг\\cpiotools\\InitramfsTool\\bin\\Debug\\netcoreapp3.1\\zynq\\initramfs.bin.SD";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.LegacyFsReader(Fn);
            Importer.ReadToFs(Fs);

            Fs.Dump();
        }

        static void TestImportRamFsCpio()
        {
            var Fn = "initramfs.bin.SD";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.LegacyFsReader(Fn);
            Importer.ReadToFs(Fs);

            Fs.Dump();
        }
        static void TestImportRamFsCpioExportNative()
        {
            var Fn = "F:\\Проекты\\Асик конфиг\\cpiotools\\InitramfsTool\\bin\\Debug\\netcoreapp3.1\\initramfs.bin.SD";
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
            var Fn = "F:\\Проекты\\Асик конфиг\\cpiotools\\InitramfsTool\\bin\\Debug\\netcoreapp3.1\\initramfs.bin.SD";
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
            var Fn = "F:\\Проекты\\Асик конфиг\\cpiotools\\InitramfsTool\\bin\\Debug\\netcoreapp3.1\\initramfs.bin.SD";
            var Dst = "ramfs.gz";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.LegacyFsReader(Fn);
            Importer.ReadToFs(Fs);

            Fs.Dump();

            var Exporter = new NyaFs.ImageFormat.Fs.Writer.GzCpioWriter(Dst);
            Exporter.WriteFs(Fs);
        }

        static void TestImportRamFsCpioExportRamFsCpio()
        {
            var Fn = "F:\\Проекты\\Асик конфиг\\cpiotools\\InitramfsTool\\bin\\Debug\\netcoreapp3.1\\initramfs.bin.SD";
            var Dst = "initramfs.bin.SD";

            var Fs = new NyaFs.ImageFormat.Fs.Filesystem();
            var Importer = new NyaFs.ImageFormat.Fs.Reader.LegacyFsReader(Fn);
            Importer.ReadToFs(Fs);

            Fs.Dump();

            var Exporter = new NyaFs.ImageFormat.Fs.Writer.LegacyFsWriter(Dst);
            Exporter.WriteFs(Fs);
        }
    }
}
