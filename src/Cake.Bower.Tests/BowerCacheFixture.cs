using System;
using Cake.Testing.Fixtures;

namespace Cake.Bower.Tests
{
    public class BowerCacheFixture : ToolFixture<BowerCacheSettings>
    {
        public BowerCacheFixture() : base("bower") { }

        public Action<BowerCacheSettings> CacheSettings { get; set; }

        protected override void RunTool()
        {
            var tool = new BowerRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Cache(CacheSettings);
        }
    }
}