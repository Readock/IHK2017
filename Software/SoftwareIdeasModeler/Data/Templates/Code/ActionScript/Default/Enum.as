<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=private==%>
<%==SIM:Set:package=public==%>
<%==SIM:Set:public=public==%>
package <%==SIM:Element.Namespace==%>
{
	<%==SIM:ForEach:Imports==%>
	import <%==SIM:Import.Name==%>;
	<%==SIM:EndFor==%>

    <%==SIM:ForEach:Element.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
    <%==SIM:EndFor==%><%==SIM:Element.Visibility==%> final class <%==SIM:Element.Name==%>
    {
<%==SIM:ForEach:Element.Attributes==%>
        <%==SIM:ForEach:Attribute.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
        <%==SIM:EndFor==%>public static const <%==SIM:Attribute.Name==%>:String = "<%==SIM:Attribute.Name==%>";
<%==SIM:EndFor==%>
    }
}