<?xml version="1.0" encoding="utf-8"?><xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"><xsl:output method="text" indent="yes"/><xsl:template match="root"><root>{
    "ResAprDatCre": "<xsl:value-of select="ValidacionAprobada"/>",
    "EsCliExc": "<xsl:value-of select="ClienteExclusivo"/>",
    "ObsCliExc": "<xsl:value-of select="ObservacionesComportamientoPago"/>",
    }</root></xsl:template></xsl:stylesheet>