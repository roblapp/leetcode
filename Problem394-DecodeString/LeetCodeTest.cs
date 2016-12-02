using System;
using NUnit.Framework;
using Playground;

namespace PlaygroundBCL
{
    [TestFixture]
    public class LeetCodeTest
    {
        private Solution solution;

        [SetUp]
        public void Init()
        {
            solution = new Solution();
        }

        [Test]
        public void IsValidString_NullParameters_Succeeds()
        {
            var result = solution.IsValidString(null);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidString_WhitespaceParameters_Succeeds()
        {
            var result = solution.IsValidString("\t\n");

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidString_ValidParameters_Test1_Succeeds()
        {
            var result = solution.IsValidString("3[a2[c4[a]]]");

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidString_ValidParameters_Test2_Succeeds()
        {
            var result = solution.IsValidString("[[][][[]]]");

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidString_InvalidParameters_Test1_Succeeds()
        {
            var result = solution.IsValidString("a[[bc");

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidString_InvalidParameters_Test2_Succeeds()
        {
            var result = solution.IsValidString("]]]");

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidString_InvalidParameters_Test3_Succeeds()
        {
            var result = solution.IsValidString("]][[");

            Assert.IsFalse(result);
        }

        

        [Test]
        public void Parse_NullParameters_Succeeds()
        {
            var result = solution.Parse(null);

            Assert.IsNotNull(result);
        }


        [Test]
        public void Parse_ValidParameters_Test1_Succeeds()
        {
            var input = "3[a]2[bc]";

            var result = solution.Parse(input);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("a", result[0].Data);
            Assert.AreEqual(3, result[0].Freq);
            Assert.AreEqual(0, result[0].Order);
            Assert.AreEqual("bc", result[1].Data);
            Assert.AreEqual(2, result[1].Freq);
            Assert.AreEqual(1, result[1].Order);
        }

        [Test]
        public void Parse_ValidParameters_Test2_Succeeds()
        {
            var input = "300[a]250[bc]";

            var result = solution.Parse(input);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("a", result[0].Data);
            Assert.AreEqual(300, result[0].Freq);
            Assert.AreEqual(0, result[0].Order);

            Assert.AreEqual("bc", result[1].Data);
            Assert.AreEqual(250, result[1].Freq);
            Assert.AreEqual(1, result[1].Order);
        }

        [Test]
        public void Parse_ValidParameters_Test3_Succeeds()
        {
            var input = "300[a]250[bc]abcd";

            var result = solution.Parse(input);

            Assert.AreEqual(3, result.Count);

            Assert.AreEqual("a", result[0].Data);
            Assert.AreEqual(300, result[0].Freq);
            Assert.AreEqual(0, result[0].Order);

            Assert.AreEqual("bc", result[1].Data);
            Assert.AreEqual(250, result[1].Freq);
            Assert.AreEqual(1, result[1].Order);

            Assert.AreEqual("abcd", result[2].Data);
            Assert.AreEqual(1, result[2].Freq);
            Assert.AreEqual(2, result[2].Order);
        }

        [Test]
        public void Parse_ValidParameters_Test4_Succeeds()
        {
            var input = "abcd";

            var result = solution.Parse(input);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            Assert.AreEqual("abcd", result[0].Data);
            Assert.AreEqual(1, result[0].Freq);
            Assert.AreEqual(0, result[0].Order);
        }

        [Test]
        public void Parse_ValidParameters_Test5_Succeeds()
        {
            var input = "[abcd]";

            var result = solution.Parse(input);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            Assert.AreEqual("abcd", result[0].Data);
            Assert.AreEqual(1, result[0].Freq);
            Assert.AreEqual(0, result[0].Order);
        }

        [Test]
        public void Parse_ValidParameters_Test6_Succeeds()
        {
            var input = "300[a]250[bc]3[3[ab]]abcd";

            var result = solution.Parse(input);

            Assert.AreEqual(4, result.Count);

            Assert.AreEqual("a", result[0].Data);
            Assert.AreEqual(300, result[0].Freq);
            Assert.AreEqual(0, result[0].Order);

            Assert.AreEqual("bc", result[1].Data);
            Assert.AreEqual(250, result[1].Freq);
            Assert.AreEqual(1, result[1].Order);

            Assert.AreEqual("3[ab]", result[2].Data);
            Assert.AreEqual(3, result[2].Freq);
            Assert.AreEqual(2, result[2].Order);

            Assert.AreEqual("abcd", result[3].Data);
            Assert.AreEqual(1, result[3].Freq);
            Assert.AreEqual(3, result[3].Order);
        }
        
        [Test]
        public void Parse_ValidParameters_Test7_Succeeds()
        {
            var input = "abcd101[abcd]";

            var result = solution.Parse(input);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("abcd", result[0].Data);
            Assert.AreEqual(1, result[0].Freq);
            Assert.AreEqual(0, result[0].Order);

            Assert.AreEqual("abcd", result[1].Data);
            Assert.AreEqual(101, result[1].Freq);
            Assert.AreEqual(1, result[1].Order);
        }

        [Test]
        public void Parse_ValidParameters_Test8_Succeeds()
        {
            var input = "x2[2[2[st]er]d]abc";

            var result = solution.Parse(input);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);

            Assert.AreEqual("x", result[0].Data);
            Assert.AreEqual(1, result[0].Freq);
            Assert.AreEqual(0, result[0].Order);

            Assert.AreEqual("2[2[st]er]d", result[1].Data);
            Assert.AreEqual(2, result[1].Freq);
            Assert.AreEqual(1, result[1].Order);

            Assert.AreEqual("abc", result[2].Data);
            Assert.AreEqual(1, result[2].Freq);
            Assert.AreEqual(2, result[2].Order);
        }

        [Test]
        public void Parse_ValidParameters_Test8_Fails()
        {
            var input = "x2[2[2[st]er]d]]abc";

            var result = solution.Parse(input);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void IsProcessingComplete_NullParameters_ThrowsException()
        {
            Assert.Throws(
                Is.TypeOf<ArgumentNullException>(),
                () =>
                {
                    solution.IsProcessingComplete(null);
                });
        }
        
        [Test]
        public void DecodeString_ValidParameters_Test1_Succeeds()
        {
            var input = "abcd";

            var result = solution.DecodeString(input);

            Assert.AreEqual("abcd", result);
        }

        [Test]
        public void DecodeString_ValidParameters_Test2_Succeeds()
        {
            var input = "2[abcd]";

            var result = solution.DecodeString(input);

            Assert.AreEqual("abcdabcd", result);
        }

        [Test]
        public void DecodeString_ValidParameters_Test3_Succeeds()
        {
            var input = "2[x]2[y]2[z]";

            var result = solution.DecodeString(input);

            Assert.AreEqual("xxyyzz", result);
        }

        [Test]
        public void DecodeString_ValidParameters_Test4_Succeeds()
        {
            var input = "2[x]2[y]zz";

            var result = solution.DecodeString(input);

            Assert.AreEqual("xxyyzz", result);
        }

        [Test]
        public void DecodeString_ValidParameters_Test5_Succeeds()
        {
            var input = "2[x2[a]]";

            var result = solution.DecodeString(input);

            Assert.AreEqual("xaaxaa", result);
        }

        [Test]
        public void DecodeString_ValidParameters_Test6_Succeeds()
        {
            var input = "2[x2[a2[xy]]]";

            var result = solution.DecodeString(input);

            Assert.AreEqual("xaxyxyaxyxyxaxyxyaxyxy", result);
        }

        [Test]
        public void DecodeString_ValidParameters_Test7_Succeeds()
        {
            var input = "2[x2[a2[xy]s]t]k";

            var result = solution.DecodeString(input);

            Assert.AreEqual("xaxyxysaxyxystxaxyxysaxyxystk", result);
        }

        [Test]
        public void DecodeString_ValidParameters_Test8_Succeeds()
        {
            var input = "3[a]2[bc]";

            var result = solution.DecodeString(input);

            Assert.AreEqual("aaabcbc", result);
        }

        [Test]
        public void DecodeString_ValidParameters_Test9_Succeeds()
        {
            var input = "3[a2[c]]";

            var result = solution.DecodeString(input);

            Assert.AreEqual("accaccacc", result);
        }

        [Test]
        public void DecodeString_ValidParameters_Test10_Succeeds()
        {
            var input = "2[abc]3[cd]ef";

            var result = solution.DecodeString(input);

            Assert.AreEqual("abcabccdcdcdef", result);
        }
    }
}
