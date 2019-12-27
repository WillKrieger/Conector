<?xml version="1.0" encoding="utf-8"?><xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"><xsl:output method="text" indent="yes"/><xsl:template match="root"><root>{
    "TipoDocumento": [
    "<xsl:value-of select="TipoDocumento"/>",
    ],
    "PaisExpedicion": [
    "<xsl:value-of select="PaisExpedicion"/>",
    ],
    "NumeroDocumento": "<xsl:value-of select="NumeroDocumento"/>",
    "NumeroTelefono": "<xsl:value-of select="NumeroTelefono"/>",
    "Correo": "<xsl:value-of select="Correo"/>",
    "Procesado": "<xsl:value-of select="Procesado"/>",
    "HayError": "<xsl:value-of select="HayError"/>",
    <xsl:if test = "HavePayTaxesAnotherCountry = 'Sí'">
        "HavePayTaxesAnotherCountry": true,
    </xsl:if>
    <xsl:if test = "HavePayTaxesAnotherCountry = 'No'">
        "HavePayTaxesAnotherCountry": false,
    </xsl:if>
    "TaxesRecipientCountry": "<xsl:value-of select="TaxesRecipientCountry"/>",
    }</root></xsl:template></xsl:stylesheet>