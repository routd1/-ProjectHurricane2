public static String PrintXML(String XML)
{
String Result = "";

MemoryStream mStream = new MemoryStream();
XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
XmlDocument document   = new XmlDocument();

try
{
	// Load the XmlDocument with the XML.
	document.LoadXml(XML);

	writer.Formatting = Formatting.Indented;

	// Write the XML into a formatting XmlTextWriter
	document.WriteContentTo(writer);
	writer.Flush();
	mStream.Flush();

	// Have to rewind the MemoryStream in order to read
	// its contents.
	mStream.Position = 0;

	// Read MemoryStream contents into a StreamReader.
	StreamReader sReader = new StreamReader(mStream);

	// Extract the text from the StreamReader.
	String FormattedXML = sReader.ReadToEnd();

	Result = FormattedXML;
}
catch (XmlException)
{
}

mStream.Close();
writer.Close();

return Result;
}