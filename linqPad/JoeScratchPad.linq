<Query Kind="Program">
  <Reference Relative="..\src\FluentJdf\bin\Debug\FluentJdf.dll">C:\development\jwf\src\FluentJdf\bin\Debug\FluentJdf.dll</Reference>
  <Namespace>FluentJdf.LinqToJdf</Namespace>
</Query>

void Main() {

	var basePath = new FileInfo(Util.CurrentQueryPath).DirectoryName;
	var ticket = FluentJdf.LinqToJdf.Ticket.Load(Path.Combine(basePath, @"..\src\Tests\FluentJdf.Tests\TestData\ProcessTwoMediaFiery.jdf"));

	//ticket.Dump();
	
	var reader = XmlReader.Create(new StringReader(ticket.ToString()));
	var nameTable = reader.NameTable;
	var namespaceManager = new XmlNamespaceManager(nameTable);
	namespaceManager.AddNamespace("ns", "http://www.CIP4.org/JDFSchema_1_1");
	
	var node = ticket.XPathSelectElement("//ns:ResourceLinkPool", namespaceManager);
	//node.Dump();
	
	var jdf = node.XPathSelectElements("//ns:JDF", namespaceManager);
	
	//jdf.Dump();

	var pt = node.GetJdfNodesContainingProcessType("DigitalPrinting");
	
	pt.Dump();

}

// Define other methods and classes here
/*

	var toParse = "process:DigitalPrinting/DigitalPrintingParams"; //"process:DigitalPrinting/DigitalPrintingParams[@usage=output]/./rest";
	var parse = FluentJdf.LinqToJdf.ProcessXPathParser.Parse(toParse);
	parse.Dump();


*/