<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxsl">
    <xsl:output method="text" indent="yes"/>
    <xsl:template match="root">
        <root>
            {
                "TipoNegocio": ["<xsl:value-of select="TipoNeg" />"],
                "ComentarioNegocio": "<xsl:value-of select="ComentarioNegocio" />",
                "NegocioEnDomicilio": "<xsl:choose><xsl:when test = "InscCamComercio = 'Si'">true</xsl:when><xsl:when test = "InscCamComercio = 'No'">False</xsl:when><xsl:otherwise><xsl:value-of select="NegEnDom" /></xsl:otherwise></xsl:choose>",
                "ActividadSector": ["<xsl:value-of select="NomSecEco"/>", "<xsl:value-of select="NomActEco"/>"],
                "NombreNegocio": "<xsl:value-of select="NombreNeg" />",
                "TiempoExperiencia": "<xsl:value-of select="TiempoExpNeg" />",
                "TiempoOperacion": "<xsl:value-of select="TiempoOpeNeg" />",
                "InscritoCamaraComercio": "<xsl:choose><xsl:when test = "InscCamComercio = 'Si'">true</xsl:when><xsl:when test = "InscCamComercio = 'No'">False</xsl:when><xsl:otherwise><xsl:value-of select="InscCamComercio" /></xsl:otherwise></xsl:choose>",
                "EmpleadosFijos": "<xsl:value-of select="NumEmpleadoFij" />",
                "EmpleadosTemporales": "<xsl:value-of select="NumEmpleadoTem" />",
                "IngresosMensuales": "<xsl:value-of select="IngPromMens" />",
                "EgresosMensuales": "<xsl:value-of select="EgrPromMens" />",
                "DireccionNegocio": "<xsl:value-of select="InfoLugTra/FormEditResponse/InformacionNeg/SubForm1/DirNeg" />",
                "PosicionNegocio":  {"Longitude":"<xsl:value-of select="InfoLugTra/FormEditResponse/InformacionNeg/SubForm1/UbicacionNegocio/manualLng" />", 
                                     "Latitude":"<xsl:value-of select="InfoLugTra/FormEditResponse/InformacionNeg/SubForm1/UbicacionNegocio/manualLat" />"},
                "ReferenciaUbicacion": "<xsl:value-of select="InfoLugTra/FormEditResponse/InformacionNeg/SubForm1/RefUbiNeg" />",
                "TelefonoNegocio": "<xsl:value-of select="InfoLugTra/FormEditResponse/InformacionNeg/SubForm1/TelNeg" />",
                "Activos": [
                <xsl:for-each select="ActNeg/FormEditResponse/ActivosNeg">
                    {
                    "TipoActivo": "<xsl:value-of select="ActivosNeg/TipoActivo" />",
                    "DescripcionActivo": "<xsl:value-of select="ActivosNeg/DescActivo" />",
                    "ValorAnterior": "<xsl:value-of select="ActivosNeg/ValorAnt" />",
                    "ValorActual": "<xsl:value-of select="ActivosNeg/ValorAct" />",
                    "FechaAdquisicion": "<xsl:value-of select="ActivosNeg/FechAdq" />",
                    "OrigenActivo": "<xsl:value-of select="ActivosNeg/OrigenAct" />",
                    "ValorComercial": "<xsl:value-of select="ActivosNeg/ValorCom" />",
                    "Valorizacion": "<xsl:value-of select="ActivosNeg/Valorizacion" />"
                    },
                </xsl:for-each>
                ]
            }
        </root>
    </xsl:template>
</xsl:stylesheet>
