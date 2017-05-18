<?php
<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package=public==%><%==SIM:Set:public=public==%>
<%==SIM:ForEach:Element.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
<%==SIM:EndFor==%><%==SIM:If:Element.IsAbstract==%> abstract<%==SIM:EndIf==%> class <%==SIM:Element.Name==%><%==SIM:If:Element.HasSuperClass==%> extends <%==SIM:Element.SuperClass.Name==%><%==SIM:EndIf==%> <%==SIM:If:Element.HasInterfaces==%>implements <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%>
{
<%==SIM:ForEach:Element.AllAttributes==%>
    /**<%==SIM:ForEach:Attribute.DocumentationLines==%>
     * <%==SIM:DocumentationLine==%><%==SIM:EndFor==%>
     * @var <%==SIM:Attribute.Type==%>
     */
    <%==SIM:Attribute.Visibility==%> $<%==SIM:Attribute.Name==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
<%==SIM:EndFor==%>


<%==SIM:ForEach:Element.Operations==%>
    <%==SIM:ForEach:Operation.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
    <%==SIM:EndFor==%><%==SIM:Operation.Visibility==%><%==SIM:If:Operation.IsAbstract==%> abstract<%==SIM:EndIf==%> function <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> $<%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Operation.IsAbstract==%>;<%==SIM:EndIf==%><%==SIM:IfNot:Operation.IsAbstract==%>        
    {
      <%==SIM:Operation.SourceCodeBody==%>
    }<%==SIM:EndIf==%>

<%==SIM:EndFor==%>
}
?>