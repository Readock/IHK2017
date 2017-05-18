<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:If:GreaterThan(Element.References.Count,0)==%>
-- References for <%==SIM:Element.Name==%> --------------------------<%==SIM:Line==%>
ALTER TABLE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]<%==SIM:Line==%>
ADD<%==SIM:Space==%>
<%==SIM:ForEach:Element.References==%>
	CONSTRAINT <%==SIM:IfNot:IsEmpty(Reference.Name)==%><%==SIM:Reference.Name==%><%==SIM:EndIf==%><%==SIM:If:IsEmpty(Reference.Name)==%>FK_<%==SIM:Element.Name==%>_<%==SIM:Reference.Uid==%><%==SIM:EndIf==%> FOREIGN KEY (<%==SIM:ForEach:Reference.ForeignKeyAttributes==%><%==SIM:Attribute.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) REFERENCES [<%==SIM:Coalesce(Reference.PrimaryKeyEntity.Schema,"dbo")==%>].[<%==SIM:Reference.PrimaryKeyEntity.Name==%>] (<%==SIM:ForEach:Reference.PrimaryKeyAttributes==%><%==SIM:Attribute.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
	<%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>

GO<%==SIM:Line(1)==%>
<%==SIM:EndIf==%>