<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

package <%==SIM:Element.Namespace==%>;
<%==SIM:Line==%>

<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package= ==%>
<%==SIM:Set:public=public==%>

<%==SIM:ForEach:Imports==%>
	import <%==SIM:Import.Name==%>;
	<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
	//<%==SIM:DocumentationLine==%>
	<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:Element.Visibility==%> enum <%==SIM:Element.Name==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

	<%==SIM:ForEach:Element.Attributes==%>
		<%==SIM:ForEach:Attribute.DocumentationLines==%>
			//<%==SIM:DocumentationLine==%>
		<%==SIM:EndFor==%>
		
		<%==SIM:Attribute.Name==%>
		<%==SIM:IfNot:IsLastItem==%>,<%==SIM:Line==%><%==SIM:EndIf==%>
	<%==SIM:EndFor==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>
