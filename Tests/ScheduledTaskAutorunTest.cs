#nullable enable

using System;
using AutoAutoruns.Autoruns.Base;
using FluentAssertions;
using Microsoft.Win32.TaskScheduler;
using Xunit;

namespace Tests {

    public class ScheduledTaskAutorunTest: IDisposable {

        private readonly Task scheduledTask;

        public ScheduledTaskAutorunTest() {
            cleanUp();
            scheduledTask = TaskService.Instance.Execute("winver.exe").AsTask(@"\Ben\test");
        }

        public void Dispose() {
            cleanUp();
        }

        private static void cleanUp() {
            TaskService.Instance.RootFolder.SubFolders["Ben"].DeleteTask("test", false);
        }

        [Fact]
        public void enabledTrue() {
            Autorun autorun = new MyScheduledTaskAutorun("Test", @"\Ben\test");
            autorun.enabled.Should().BeTrue();
        }

        [Fact]
        public void enabledFalse() {
            Autorun autorun = new MyScheduledTaskAutorun("Test", @"\Ben\test_missing");
            autorun.enabled.Should().BeFalse();
        }

        [Fact]
        public void disable() {
            Autorun autorun = new MyScheduledTaskAutorun("Test", @"\Ben\test");
            autorun.enabled.Should().BeTrue();
            scheduledTask.Enabled.Should().BeTrue();

            autorun.enabled = false;
            scheduledTask.Enabled.Should().BeFalse();
        }

        private class MyScheduledTaskAutorun: ScheduledTaskAutorun {

            public MyScheduledTaskAutorun(string name, string path) {
                this.name = name;
                this.path = path;
            }

            public override string name { get; }
            protected override string path { get; }

        }

    }

}