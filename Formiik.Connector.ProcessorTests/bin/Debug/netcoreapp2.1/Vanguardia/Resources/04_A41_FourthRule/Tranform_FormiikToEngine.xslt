<?xml version="1.0" encoding="utf-8"?><xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"><xsl:output method="text" indent="yes"/><xsl:template match="root"><root>{
    "ConAprAna": "<xsl:value-of select="ObservacionesAsesor"/>",
    "IdeDes": [
    "<xsl:value-of select="SugerenciaAsesor"/>",
    ],
    }</root></xsl:template></xsl:stylesheet>