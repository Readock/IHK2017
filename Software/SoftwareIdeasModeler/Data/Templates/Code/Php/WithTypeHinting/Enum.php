<?php
<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package=public==%><%==SIM:Set:public=public==%>
<%==SIM:ForEach:Element.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
<%==SIM:EndFor==%>final class <%==SIM:Element.Name==%> {
<%==SIM:ForEach:Element.Attributes==%>
<%==SIM:ForEach:Element.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
<%==SIM:EndFor==%>    const <%==SIM:Attribute.Name==%> <%==SIM:If:Attribute.HasDefaultValue==%>= <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
<%==SIM:EndFor==%>
    private function __construct(){}
}
?>
