<?xml version="1.0" encoding="utf-8"?><xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"><xsl:output method="text" indent="yes"/><xsl:template match="root"><root>{
    "NombreNegocio": "<xsl:value-of select="NombreNegocio"/>",
    "BarrioNegocio": {
    "DireccionNegocio": "<xsl:value-of select="DireccionNegocio"/>",
    "DeptoMunicipioBarrioNegocio": [
    "<xsl:value-of select="DepartamentoNegocio"/>",
    "<xsl:value-of select="CiudadNegocio"/>",
    "<xsl:value-of select="BarrioNegocio"/>",
    ],
    },
    "ConActEco": [
    "<xsl:value-of select="Sector"/>",
    "<xsl:value-of select="Actividad"/>",
    ],
    "FechaInicioNegocio": "<xsl:value-of select="FechaInicioNegocio"/>",
    "Destino": [
    "<xsl:value-of select="Destino"/>",
    ],
    "FormaPago": [
    "<xsl:value-of select="FormaPago"/>",
    ],
    "Monto": "<xsl:value-of select="Monto"/>",
    "Plazo": "<xsl:value-of select="Plazo"/>",
    "Producto": [
    "<xsl:value-of select="Producto"/>",
    ],
    }</root></xsl:template></xsl:stylesheet>