<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxsl">
    <xsl:output method="text" indent="yes"/>
    <xsl:template match="root">
        <root>
            {
            "ProyNroCreGenExt": "<xsl:value-of select="ProyNroCreGenExt"/>",
            "ValCuoyPerUltCreDes": "<xsl:value-of select="ValCuoyPerUltCreDes"/>",
            "ReaConIntSol": "<xsl:value-of select="ReaConIntSol"/>",
            "ProSug": ["<xsl:value-of select="ProSug"/>", "<xsl:value-of select="DesCre"/>"],
            "MonSug": "<xsl:value-of select="MonSug"/>",
            "PlaSug": "<xsl:value-of select="PlaSug"/>",
            "CuoMaxRec": "<xsl:value-of select="CuoMaxRec"/>",
            "ReqCorInfDil": "<xsl:value-of select="ReqCorInfDil"/>",
            "MenResConRut": "<xsl:value-of select="MenResConRut"/>",
            "ValCuoRec": "<xsl:value-of select="ValCuoRec"/>",
            "ValTotPolOfrCli": "<xsl:value-of select="ValTotPolOfrCli"/>",
            "RutFor": "<xsl:value-of select="RutFor"/>",
            "RecEva": ["<xsl:value-of select="RecEva"/>"],
            "CauDenEva": ["<xsl:value-of select="CauDenEva"/>"],
            "DesAgeNueVis": "<xsl:value-of select="DesAgeNueVis"/>",
            "FecProVis": "<xsl:value-of select="FecProVis"/>",
            "ObsRecEva": "<xsl:value-of select="ObsRecEva"/>"
            }
        </root>
    </xsl:template>
</xsl:stylesheet>