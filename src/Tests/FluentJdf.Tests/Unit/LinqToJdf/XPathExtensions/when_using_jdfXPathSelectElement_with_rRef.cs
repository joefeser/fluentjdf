﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Testing;
using Machine.Specifications;
using FluentJdf.LinqToJdf;
using System.Xml.Linq;
using l = FluentJdf.LinqToJdf;
using x = FluentJdf.LinqToJdf.XPathExtensions;

namespace FluentJdf.Tests.Unit.LinqToJdf.XPathExtensions {

    [Subject(typeof(FluentJdf.LinqToJdf.XPathExtensions))]
    public class when_using_jdfXPathSelectElement_with_rRef {

        static XDocument ticket;

        Establish context = () => {
            ticket = l.Ticket.Load(TestDataHelper.Instance.PathToTestFile("ProcessTwoMediaFiery.jdf"));
        };

        It should_have_two_media_items_in_resource_pool =
            () => x.JdfXPathSelectElements(ticket, @"/JDF/ResourcePool/Media").Count().ShouldEqual(2);
    }
}
