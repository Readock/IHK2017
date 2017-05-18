<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

-- Table <%==SIM:Element.Name==%> --------------------------<%==SIM:Line==%>
<%==SIM:ForEach:Element.DocumentationLines==%>
	--<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>

CREATE TABLE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]<%==SIM:Line==%>
(<%==SIM:StartBlock==%><%==SIM:Line==%>

<%==SIM:ForEach:Element.Attributes==%>
	[<%==SIM:Attribute.Name==%>] [<%==SIM:Attribute.TypeName==%>] 
	<%==SIM:If:Attribute.HasTypeLength==%>(<%==SIM:Attribute.TypeLength==%>) <%==SIM:EndIf==%> 
	<%==SIM:If:Attribute.IsNullable==%>NULL<%==SIM:EndIf==%>
	<%==SIM:IfNot:Attribute.IsNullable==%>NOT NULL<%==SIM:EndIf==%>
	<%==SIM:If:Attribute.IsAutoIncrement==%> IDENTITY (1, 1)<%==SIM:EndIf==%>
	<%==SIM:If:Attribute.HasDefaultValue==%> CONSTRAINT DF_<%==SIM:Element.Name==%>_<%==SIM:Attribute.Name==%> DEFAULT <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
	<%==SIM:IfNot:IsLastItem==%>,<%==SIM:Line==%><%==SIM:EndIf==%>
<%==SIM:EndFor==%>

<%==SIM:If:Element.HasPrimaryKey==%>
	,<%==SIM:Line==%>
	CONSTRAINT <%==SIM:Element.PrimaryKeyName==%><%==SIM:Space==%> 
	PRIMARY KEY (
	<%==SIM:ForEach:Element.PrimaryKeys==%>
	<%==SIM:Key.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%>
	<%==SIM:EndFor==%>)	
<%==SIM:EndIf==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
)<%==SIM:Line==%>
<%==SIM:EndIf==%>
GO<%==SIM:Line(2)==%>

<%==SIM:ForEach:Element.Attributes==%><%==SIM:If:Attribute.HasDescription==%>
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'<%==SIM:Attribute.Description==%>' , @level0type=N'SCHEMA',@level0name=N'<%==SIM:Coalesce(Element.Schema,"dbo")==%>', @level1type=N'TABLE',@level1name=N'<%==SIM:Element.Name==%>', @level2type=N'COLUMN',@level2name=N'<%==SIM:Attribute.Name==%>'<%==SIM:Line==%>
GO<%==SIM:Line(2)==%>
<%==SIM:EndIf==%><%==SIM:EndFor==%>
<%==SIM:If:Or(Not(IsEmpty(Element.Description)),Element.HasTaggedValue(Description))==%>
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'<%==SIM:Coalesce(Element.Description,Element.GetTaggedValue(Description))==%>' , @level0type=N'SCHEMA',@level0name=N'<%==SIM:Coalesce(Element.Schema,"dbo")==%>', @level1type=N'TABLE',@level1name=N'<%==SIM:Element.Name==%>'<%==SIM:Line==%>
GO<%==SIM:Line(2)==%>
<%==SIM:EndIf==%>


<%==SIM:IfNot:Element.Indexes.IsEmpty==%>
-- Indexes of table <%==SIM:Element.Name==%> ------------------------------<%==SIM:Line==%>
<%==SIM:ForEach:Element.Indexes==%>
CREATE <%==SIM:If:Index.IsUnique==%>UNIQUE<%==SIM:EndIf==%><%==SIM:IfNot:Index.IsUnique==%>NONCLUSTERED<%==SIM:EndIf==%> INDEX <%==SIM:Index.Name==%> ON [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]<%==SIM:Line==%>
(
<%==SIM:ForEach:Index.Attributes==%>
	<%==SIM:IndexAttribute.Name==%><%==SIM:IfNot:IsLastItem==%>,<%==SIM:EndIf==%><%==SIM:EndFor==%>	
) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]<%==SIM:Line==%>
GO<%==SIM:Line(2)==%>
<%==SIM:EndFor==%>
<%==SIM:EndIf==%>


<%==SIM:IfNot:Element.DataRows.IsEmpty==%>
-- Data of table <%==SIM:Element.Name==%> ------------------------------<%==SIM:Line==%>
<%==SIM:ForEach:Element.DataRows==%>
INSERT INTO [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>] (<%==SIM:ForEach:Element.Attributes==%>[<%==SIM:Attribute.Name==%>]<%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
VALUES (<%==SIM:ForEach:DataRow.Values==%>'<%==SIM:Value==%>'<%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>
<%==SIM:EndIf==%>
