<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
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
            <TipoDocumento>
                <xsl:value-of select="Root/values/TipoDocumento[1]"/>
            </TipoDocumento>
            <PaisExpedicion>
                <xsl:value-of select="Root/values/PaisExpedicion[1]"/>
            </PaisExpedicion>
            <NumeroDocumento>
                <xsl:value-of select="Root/values/NumeroDocumento"/>
            </NumeroDocumento>
            <NumeroTelefono>
                <xsl:value-of select="Root/values/NumeroTelefono"/>
            </NumeroTelefono>
            <Correo>
                <xsl:value-of select="Root/values/Correo"/>
            </Correo>
            <Procesado>
                <xsl:value-of select="Root/values/Procesado"/>
            </Procesado>
            <HayError>
                <xsl:value-of select="Root/values/HayError"/>
            </HayError>

            <xsl:if test = "Root/values/HavePayTaxesAnotherCountry = 'true'">
                <HavePayTaxesAnotherCountry><xsl:text>Si</xsl:text></HavePayTaxesAnotherCountry>
            </xsl:if>
            <xsl:if test = "Root/values/HavePayTaxesAnotherCountry = 'false'">
                <HavePayTaxesAnotherCountry><xsl:text>No</xsl:text></HavePayTaxesAnotherCountry>
            </xsl:if>

            <TaxesRecipientCountry>
                <xsl:value-of select="Root/values/TaxesRecipientCountry"/>
            </TaxesRecipientCountry>
        </root>
    </xsl:template>
</xsl:stylesheet>