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
    <%==SIM:EndFor==%><%==SIM:Element.Visibility==%> class <%==SIM:Element.Name==%> <%==SIM:If:Element.HasSuperClass==%>extends <%==SIM:Element.SuperClass.Name==%><%==SIM:EndIf==%> <%==SIM:If:Element.HasInterfaces==%>implements <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%>
    {
<%==SIM:ForEach:Element.AllAttributes==%>
        <%==SIM:ForEach:Attribute.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
        <%==SIM:EndFor==%><%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%> var <%==SIM:Attribute.Name==%>:<%==SIM:Attribute.Type==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Operations==%>
        <%==SIM:ForEach:Operation.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
        <%==SIM:EndFor==%><%==SIM:Operation.Visibility==%><%==SIM:If:Operation.IsStatic==%> static<%==SIM:EndIf==%> function  <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%>:<%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>):<%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%>
        {
            <%==SIM:Operation.SourceCodeBody==%>
        }<%==SIM:EndIf==%>
<%==SIM:EndFor==%>
    }
}