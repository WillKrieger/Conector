<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="text" indent="yes"/>
    <xsl:template match="root">
        <root>{
            "NombreNegocio": "<xsl:value-of select="NombreNegocio"/>",
            "LocalizacionDomicilioNegocio": {
            "CalleYNumero": "<xsl:value-of select="CalleYNumeroNegocio"/>",
            "DeptoMunicipioBarrioNegocio": [
            "<xsl:value-of select="DeptoMunicipioBarrioNegocio0ID"/>",
            "<xsl:value-of select="DeptoMunicipioBarrioNegocio1ID"/>",
            "<xsl:value-of select="DeptoMunicipioBarrioNegocio2ID"/>",
            ]
            },
            "Antiguedad": "<xsl:value-of
                    select="Antiguedad"/>",}
        </root>
    </xsl:template>
</xsl:stylesheet>