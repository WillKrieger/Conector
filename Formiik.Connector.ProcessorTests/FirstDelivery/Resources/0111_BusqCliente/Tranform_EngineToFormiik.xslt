<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output indent="yes" method="xml"/>
    <xsl:template match="/">
        <root>
            <Nombre/>
            <Calle/>
            <Colonia/>
            <CodigoPostal/>
            <Estado/>
            <Municipio/>
            <Ciudad/>
            <NumCli>
                <xsl:value-of select="Root/NumeroCliente"/>
            </NumCli>
            <FolioCre>
                <xsl:value-of select="Root/FolioCredito"/>
            </FolioCre>
            <TipDocCli>
                <xsl:value-of select="Root/TipoDocumento"/>
            </TipDocCli>
            <IdReaderCedula_Cedula>
                <xsl:value-of select="Root/NumeroDocumento"/>
            </IdReaderCedula_Cedula>
        </root>
    </xsl:template>
</xsl:stylesheet>