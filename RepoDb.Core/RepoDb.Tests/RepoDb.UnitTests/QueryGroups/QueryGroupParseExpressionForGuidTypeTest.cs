﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RepoDb.UnitTests
{
    public partial class QueryGroupTest
    {
        // Guid

        [TestMethod]
        public void TestQueryGroupParseExpressionGuidConstant()
        {
            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => e.PropertyGuid == Guid.NewGuid()).GetString();
            var expected = "([PropertyGuid] = @PropertyGuid)";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestQueryGroupParseExpressionGuidVariable()
        {
            // Setup
            var value = Guid.NewGuid();

            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => e.PropertyGuid == value).GetString();
            var expected = "([PropertyGuid] = @PropertyGuid)";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestQueryGroupParseExpressionGuidClassProperty()
        {
            // Setup
            var value = new QueryGroupTestExpressionClass
            {
                PropertyGuid = Guid.NewGuid()
            };

            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => e.PropertyGuid == value.PropertyGuid).GetString();
            var expected = "([PropertyGuid] = @PropertyGuid)";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestQueryGroupParseExpressionGuidMethodCall()
        {
            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => e.PropertyGuid == GetGuidValueForParseExpression()).GetString();
            var expected = "([PropertyGuid] = @PropertyGuid)";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestQueryGroupParseExpressionGuidVariableMethodCall()
        {
            // Setup
            var value = GetGuidValueForParseExpression();

            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => e.PropertyGuid == value).GetString();
            var expected = "([PropertyGuid] = @PropertyGuid)";

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
