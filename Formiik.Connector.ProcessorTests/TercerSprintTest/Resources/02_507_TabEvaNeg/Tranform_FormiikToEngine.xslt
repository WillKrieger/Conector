<?xml version="1.0" encoding="utf-8"?><xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"><xsl:output method="text" indent="yes"/><xsl:template match="root"><root>{
    "Nombre": "<xsl:value-of select="Nombre"/>",
    "PrimerApellido": "<xsl:value-of select="PrimerApellido"/>",
    "SegundoApellido": "<xsl:value-of select="SegundoApellido"/>",
    "FechaNacimiento": "<xsl:value-of select="FechaNacimiento"/>",
    "EstadoCivil": [
    "<xsl:value-of select="EstadoCivil"/>",
    ],
    "LocalizacionDomicilioTitular": {
    "CalleYNumero": "<xsl:value-of select="CalleYNumero"/>",
    "DeptoMunicipioBarrioDomicilio": [
    "<xsl:value-of select="DeptoMunicipioBarrioDomicilio0ID"/>",
    "<xsl:value-of select="DeptoMunicipioBarrioDomicilio1ID"/>",
    "<xsl:value-of select="DeptoMunicipioBarrioDomicilio2ID"/>",
    ],
    },
    "Zona": [
    "<xsl:value-of select="Zona"/>",
    ],
    }</root></xsl:template></xsl:stylesheet>