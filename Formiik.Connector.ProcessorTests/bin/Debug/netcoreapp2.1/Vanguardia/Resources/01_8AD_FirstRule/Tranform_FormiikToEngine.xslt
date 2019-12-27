<?xml version="1.0" encoding="utf-8"?><xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"><xsl:output method="text" indent="yes"/><xsl:template match="root"><root>{
    "EsMayorEdad": "<xsl:value-of select="EsMayorEdad"/>",
    "TieneNegocio": "<xsl:value-of select="TieneNegocio"/>",
    "TiempoNegocioRequerido": "<xsl:value-of select="TiempoNegocioRequerido"/>",
    "TipoDocumento": [
    "<xsl:value-of select="TipoDocumento"/>",
    ],
    "NumeroDocumento": "<xsl:value-of select="NumeroDocumento"/>",
    "PrimerApellido": "<xsl:value-of select="PrimerApellido"/>",
    "SegundoApellido": "<xsl:value-of select="SegundoApellido"/>",
    "PrimerNombre": "<xsl:value-of select="PrimerNombre"/>",
    "SegundoNombre": "<xsl:value-of select="SegundoNombre"/>",
    "FechaNacimiento": "<xsl:value-of select="FechaNacimiento"/>",
    "EstadoCivil": [
    "<xsl:value-of select="EstadoCivil"/>",
    ],
    "BarrioResidencia": {
    "DireccionResidencia": "<xsl:value-of select="DireccionResidencia"/>",
    "DeptoMunicipioBarrioDomicilio": [
    "<xsl:value-of select="DepartamentoResidencia"/>",
    "<xsl:value-of select="CiudadResidencia"/>",
    "<xsl:value-of select="BarrioResidencia"/>",
    ],
    },
    "Telefono": "<xsl:value-of select="Telefono"/>",
    "Celular": "<xsl:value-of select="Celular"/>",
    }</root></xsl:template></xsl:stylesheet>