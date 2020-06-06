using System;
using Base.Static.Utilities;
using Xunit;

namespace Base.Test
{
    public class ObjectUtilsTest
    {
        [Fact]
        public void Equal_Reference_Same()
        {
            var demo1 = new DemoEqual()
            {
                Id = 1,
                Name = "hoinx"
            };
            var demo2 = demo1;
            Assert.True(ObjectUtils.Equal(demo1, demo2));
        }
        [Fact]
        public void Equal_Reference_NotSame()
        {
            var demo1 = new DemoEqual()
            {
                Id = 1,
                Name = "hoinx"
            };
            var demo2 = new DemoEqual()
            {
                Id = 1,
                Name = "hoinx"
            };
            Assert.True(ObjectUtils.Equal(demo1, demo2));
        }
    }
    class DemoEqual
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is DemoEqual)
            {
                return this.Id == (obj as DemoEqual).Id;
            }
            return base.Equals(obj);
        }
    }

}
