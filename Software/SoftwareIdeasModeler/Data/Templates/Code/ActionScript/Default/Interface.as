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
    <%==SIM:EndFor==%><%==SIM:Element.Visibility==%> interface <%==SIM:Element.Name==%><%==SIM:If:Element.HasSuperClassOrInterface==%> extends <%==SIM:Element.SuperClass.Name==%><%==SIM:If:Element.HasInterfaces==%><%==SIM:If:Element.HasSuperClass==%>,<%==SIM:EndIf==%> <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%><%==SIM:EndIf==%>
    {
<%==SIM:ForEach:Element.Operations==%>
    <%==SIM:ForEach:Operation.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
    <%==SIM:EndFor==%>function <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%>:<%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>):<%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%>;
<%==SIM:EndFor==%>
    }
}