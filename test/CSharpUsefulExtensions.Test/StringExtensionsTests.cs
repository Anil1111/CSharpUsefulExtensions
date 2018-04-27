﻿using FluentAssertions;
using NUnit.Framework;

namespace CSharpUsefulExtensions.Test
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void Left_EmptyString_ShouldReturnEmptyString()
        {
            var value = "";

            var result = value.Left(5);

            result.Should().BeEmpty();
        }

        [Test]
        public void Left_NullString_ShouldReturnNullString()
        {
            string value = null;

            var result = value.Left(5);

            result.Should().BeNull();
        }

        [Test]
        public void Left_StringWithLowerLengthThanGivenLength_ShouldReturnEntireString()
        {
            string value = "abcdef";

            var result = value.Left(10);

            result.Should().BeEquivalentTo(value);
        }

        [Test]
        public void Left_StringWithHigherLengthThanGivenLength_ShouldReturnLeftmostCharacters()
        {
            string value = "abcdefghijk";

            var result = value.Left(5);

            result.Should().BeEquivalentTo("abcde");
        }

        [Test]
        public void Right_EmptyString_ShouldReturnEmptyString()
        {
            var value = "";

            var result = value.Right(5);

            result.Should().BeEmpty();
        }

        [Test]
        public void Right_NullString_ShouldReturnNullString()
        {
            string value = null;

            var result = value.Right(5);

            result.Should().BeNull();
        }

        [Test]
        public void Right_StringWithLowerLengthThanGivenLength_ShouldReturnEntireString()
        {
            string value = "abcdef";

            var result = value.Right(10);

            result.Should().BeEquivalentTo(value);
        }

        [Test]
        public void Right_StringWithHigherLengthThanGivenLength_ShouldReturnRightmostCharacters()
        {
            string value = "abcdefghijk";

            var result = value.Right(5);

            result.Should().BeEquivalentTo("ghijk");
        }

        [Test]
        public void AppendIfMissing_EmptyString_ShouldReturnEmptyString()
        {
            var value = "";

            var result = value.AppendIfMissing("suffix");

            result.Should().BeEmpty();
        }

        [Test]
        public void AppendIfMissing_NullString_ShouldReturnNullString()
        {
            string value = null;

            var result = value.AppendIfMissing("suffix");

            result.Should().BeNull();
        }

        [Test]
        public void AppendIfMissing_EmptySuffix_ShouldReturnUnchangedString()
        {
            string value = "my_string";

            var result = value.AppendIfMissing("");

            result.Should().BeEquivalentTo(value);
        }

        [Test]
        public void AppendIfMissing_NullSuffix_ShouldReturnUnchangedString()
        {
            string value = "my_string";

            var result = value.AppendIfMissing(null);

            result.Should().BeEquivalentTo(value);
        }

        [Test]
        public void AppendIfMissing_StringWithAlreadyAppendedSuffixStringComparisonOrdinalIgnoreCase_ShouldReturnUnchangedString()
        {
            string suffix = "mySuffix";
            string value = "my_string" + suffix;            

            var result = value.AppendIfMissing(suffix);

            result.Should().BeEquivalentTo(value);
        }

        [Test]
        public void AppendIfMissing_StringWithAlreadyAppendedUpperCaseSuffixStringComparisonOrdinalIgnoreCase_ShouldReturnUnchangedString()
        {
            string suffix = "mySuffix";
            string value = "my_string" + suffix.ToUpper();
            
            var result = value.AppendIfMissing(suffix);

            result.Should().BeEquivalentTo(value);
        }

        [Test]
        public void AppendIfMissing_StringWithAlreadyAppendedUpperCaseSuffixStringComparisonOrdinal_ShouldReturnStringWithAddedSuffix()
        {
            string suffix = "mySuffix";
            string value = "my_string" + suffix.ToUpper();

            var result = value.AppendIfMissing(suffix, System.StringComparison.Ordinal);

            result.Should().BeEquivalentTo(value + suffix);
        }

        [Test]
        public void AppendIfMissing_StringWithoutGivenSuffixStringComparisonOrdinalIgnoreCase_ShouldReturnStringWithAppendedSuffix()
        {
            string value = "my_string";
            string suffix = "mySuffix";

            var result = value.AppendIfMissing(suffix);

            result.Should().BeEquivalentTo(value + suffix);
        }

        [Test]
        public void PrependIfMissing_EmptyString_ShouldReturnEmptyString()
        {
            var value = "";

            var result = value.PrependIfMissing("prefix");

            result.Should().BeEmpty();
        }

        [Test]
        public void PrependIfMissing_NullString_ShouldReturnNullString()
        {
            string value = null;

            var result = value.PrependIfMissing("prefix");

            result.Should().BeNull();
        }

        [Test]
        public void PrependIfMissing_EmptyPrefix_ShouldReturnUnchangedString()
        {
            string value = "my_string";

            var result = value.PrependIfMissing("");

            result.Should().BeEquivalentTo(value);
        }

        [Test]
        public void PrependIfMissing_NullPrefix_ShouldReturnUnchangedString()
        {
            string value = "my_string";

            var result = value.PrependIfMissing(null);

            result.Should().BeEquivalentTo(value);
        }

        [Test]
        public void PrependIfMissing_StringWithAlreadyPrependedPrefixStringComparisonOrdinalIgnoreCase_ShouldReturnUnchangedString()
        {
            string prefix = "MyPrefix";
            string value = prefix + "my_string";
           

            var result = value.PrependIfMissing(prefix);

            result.Should().BeEquivalentTo(value);
        }

        [Test]
        public void PrependIfMissing_StringWithAlreadyPrependedUpperCasePrefixStringComparisonOrdinalIgnoreCase_ShouldReturnUnchangedString()
        {
            string prefix = "MyPrefix";
            string value = prefix.ToUpper() + "my_string";

            var result = value.PrependIfMissing(prefix);

            result.Should().BeEquivalentTo(value);
        }

        [Test]
        public void PrependIfMissing_StringWithAlreadyPrependedUpperCasePrefixStringComparisonOrdinal_ShouldReturnStringWithAddedPrefix()
        {
            string prefix = "MyPrefix";
            string value = prefix.ToUpper() + "my_string";

            var result = value.PrependIfMissing(prefix, System.StringComparison.Ordinal);

            result.Should().BeEquivalentTo(prefix + value);
        }

        [Test]
        public void PrependIfMissing_StringWithoutGivenPrefixStringComparisonOrdinalIgnoreCase_ShouldReturnStringWithAppendedPrefix()
        {
            string value = "my_string";
            string prefix = "MyPrefix";

            var result = value.PrependIfMissing(prefix);

            result.Should().BeEquivalentTo(prefix + value);
        }

    }
}
