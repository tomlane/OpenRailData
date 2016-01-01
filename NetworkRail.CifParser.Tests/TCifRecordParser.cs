﻿using System;
using Microsoft.Practices.Unity;
using Moq;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.RecordBuilders;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests
{
    [TestFixture]
    public class TCifRecordParser
    {
        [Test]
        public void throws_when_aeguments_are_null()
        {
            var cifRecordBuilderContainerMock = new Mock<ICifRecordBuilderContainer>();

            Assert.Throws<ArgumentNullException>(() => new CifRecordParser(null));
        }

        [Test]
        public void can_be_resolved_by_di()
        {
            var container = CifParserIocContainerBuilder.Build();

            var parser = container.Resolve<ICifRecordParser>();

            Assert.IsInstanceOf<CifRecordParser>(parser);
        }

        [TestFixture]
        class ParseRecord
        {
            [Test]
            public void throws_if_argument_is_invalid()
            {
                var cifRecordBuilderContainerMock = new Mock<ICifRecordBuilderContainer>();

                var parser = new CifRecordParser(cifRecordBuilderContainerMock.Object);

                Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(" \t"));
                Assert.Throws<ArgumentNullException>(() => parser.ParseRecord("gibberish record"));
            }

            [Test]
            public void throws_if_record_type_is_not_implemented()
            {
                var cifRecordBuilderContainerMock = new Mock<ICifRecordBuilderContainer>();

                var parser = new CifRecordParser(cifRecordBuilderContainerMock.Object);

                string notImplementedRecord =
                    "XYRW01400W005701512131602070000001   ORPNGTN  T                                C";

                Assert.Throws<NotImplementedException>(() => parser.ParseRecord(notImplementedRecord));
            }
        }
    }
} 