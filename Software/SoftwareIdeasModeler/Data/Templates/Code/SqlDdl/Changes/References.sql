<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:If:GreaterThan(Element.References.Count,0)==%>

-- References for <%==SIM:Element.Name==%> --------------------------<%==SIM:Line==%>
<%==SIM:ForEach:Element.References==%>
<%==SIM:If:Reference.IsAdded==%>
ALTER TABLE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]<%==SIM:Line==%>
ADD CONSTRAINT <%==SIM:IfNot:IsEmpty(Reference.Name)==%><%==SIM:Reference.Name==%><%==SIM:EndIf==%><%==SIM:If:IsEmpty(Reference.Name)==%>FK_<%==SIM:Element.Name==%>_<%==SIM:Reference.Uid==%><%==SIM:EndIf==%> FOREIGN KEY (<%==SIM:ForEach:Reference.ForeignKeyAttributes==%><%==SIM:Attribute.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) REFERENCES <%==SIM:Reference.PrimaryKeyEntity.Name==%> (<%==SIM:ForEach:Reference.PrimaryKeyAttributes==%><%==SIM:Attribute.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
<%==SIM:Line==%>
GO
<%==SIM:Line(2)==%>
<%==SIM:EndIf==%>

<%==SIM:If:Reference.IsRemoved==%>
ALTER TABLE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]<%==SIM:Line==%>
DROP CONSTRAINT <%==SIM:IfNot:IsEmpty(Reference.Name)==%><%==SIM:Reference.Name==%><%==SIM:EndIf==%><%==SIM:If:IsEmpty(Reference.Name)==%>FK_<%==SIM:Element.Name==%>_<%==SIM:Reference.Uid==%><%==SIM:EndIf==%>
<%==SIM:Line==%>
GO
<%==SIM:Line(2)==%>
<%==SIM:EndIf==%>

<%==SIM:EndFor==%>

<%==SIM:EndIf==%>