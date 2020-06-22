#nullable enable

using System;
using AutoAutoruns.Autoruns.Base;
using FluentAssertions;
using Microsoft.Win32;
using Xunit;

namespace Tests {

    public class RegistryAutorunTest: IDisposable {

        private readonly RegistryKey testKey = Registry.CurrentUser
            .OpenSubKey("Software", true)
            .CreateSubKey("AutoAutoruns", true)
            .CreateSubKey("test", true);

        readonly RegistryAutorun namedAutorun =
            new MyAutorun("My Named Autorun", (Registry.CurrentUser, @"SOFTWARE\AutoAutoruns\test", "A"));

        readonly RegistryAutorun unnamedAutorun =
            new MyAutorun("My Unnamed Autorun", (Registry.CurrentUser, @"SOFTWARE\AutoAutoruns\test\B", null));

        public RegistryAutorunTest() => cleanUp();

        public void Dispose() => cleanUp();

        private void cleanUp() {
            try {
                testKey.DeleteValue("A");
            } catch (ArgumentException) { }

            try {
                testKey.DeleteSubKeyTree("B");
            } catch (ArgumentException) { }

            try {
                testKey.DeleteSubKeyTree("AutorunsDisabled");
            } catch (ArgumentException) { }
        }

        [Fact]
        public void isEnabledWithNameTrue() {
            testKey.SetValue("A", "a.exe");
            namedAutorun.enabled.Should().BeTrue();
        }

        [Fact]
        public void isEnabledWithNameFalse() {
            namedAutorun.enabled.Should().BeFalse();
        }

        [Fact]
        public void isEnabledWithoutNameTrue() {
            testKey.CreateSubKey("B");
            unnamedAutorun.enabled.Should().BeTrue();
        }

        [Fact]
        public void isEnabledWithoutNameFalse() {
            unnamedAutorun.enabled.Should().BeFalse();
        }

        [Fact]
        public void disableWithName() {
            testKey.SetValue("A", "a.exe");
            namedAutorun.enabled.Should().BeTrue();
            namedAutorun.enabled = false;
            testKey.GetValue("A").Should().BeNull();
            testKey.OpenSubKey("AutorunsDisabled").GetValue("A").Should().Be("a.exe");
        }

        [Fact]
        public void disableWithoutName() {
            RegistryKey subKey = testKey.CreateSubKey("B");
            subKey.SetValue(string.Empty, "b.exe");
            unnamedAutorun.enabled.Should().BeTrue();
            unnamedAutorun.enabled = false;
            subKey.GetValue(string.Empty).Should().BeNull();
            testKey.OpenSubKey("AutorunsDisabled").OpenSubKey("B").GetValue(string.Empty).Should().Be("b.exe");
        }

        private class MyAutorun: RegistryAutorun {

            public override string name { get; }
            protected override (RegistryKey hive, string path, string? name) registryLocation { get; }

            public MyAutorun(string name, (RegistryKey hive, string path, string? name) registryLocation) {
                this.name = name;
                this.registryLocation = registryLocation;
            }

        }

    }

}