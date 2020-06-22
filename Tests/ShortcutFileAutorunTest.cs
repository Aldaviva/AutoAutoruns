#nullable enable

using System;
using System.IO;
using AutoAutoruns.Autoruns.Base;
using FluentAssertions;
using Xunit;

namespace Tests {

    public class ShortcutFileAutorunTest: IDisposable {

        private readonly string tempFolder = Path.Combine(Path.GetTempPath(), "AutoAutoruns", "test");
        private readonly string filename;

        public ShortcutFileAutorunTest() {
            cleanUp();
            Directory.CreateDirectory(tempFolder);
            filename = Path.Combine(tempFolder, "a.txt");
        }

        public void Dispose() {
            cleanUp();
        }

        private void cleanUp() {
            try {
                Directory.Delete(tempFolder, true);
            } catch (DirectoryNotFoundException) { }
        }

        [Fact]
        public void isEnabledTrue() {
            File.WriteAllText(filename, "a");
            ShortcutFileAutorun autorun = new MyShortcutFileAutorun("A", filename);
            autorun.enabled.Should().BeTrue();
        }

        [Fact]
        public void isEnabledFalse() {
            ShortcutFileAutorun autorun = new MyShortcutFileAutorun("A", filename);
            autorun.enabled.Should().BeFalse();
        }

        [Fact]
        public void disable() {
            File.WriteAllText(filename, "a");
            ShortcutFileAutorun autorun = new MyShortcutFileAutorun("A", filename);
            autorun.enabled.Should().BeTrue();
            string newFile = Path.Combine(tempFolder, "AutorunsDisabled", "a.txt");
            File.Exists(newFile).Should().BeFalse();

            autorun.enabled = false;
            File.Exists(filename).Should().BeFalse();
            File.Exists(newFile).Should().BeTrue();
        }

        private class MyShortcutFileAutorun: ShortcutFileAutorun {

            public override string name { get; }
            protected override string filePath { get; }

            public MyShortcutFileAutorun(string name, string filePath) {
                this.name = name;
                this.filePath = filePath;
            }

        }

    }

}