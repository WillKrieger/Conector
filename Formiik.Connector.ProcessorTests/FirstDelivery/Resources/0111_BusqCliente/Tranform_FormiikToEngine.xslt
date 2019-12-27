<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxsl">
    <xsl:output method="text" indent="yes"/>
    <xsl:template match="root">
        <root>
            {
            "NumeroCliente": "<xsl:value-of select="NumCli"/>",
            "FolioCredito":"<xsl:value-of select="FolioCre"/>",
            "TipoDocumento":["<xsl:value-of select="TipDocCli"/>"],
            "NumeroDocumento":"<xsl:value-of select="IdReaderCedula_Cedula"/>"
            }
        </root>
    </xsl:template>
</xsl:stylesheet>
