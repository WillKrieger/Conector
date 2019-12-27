<?xml version="1.0" encoding="utf-8"?><xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"><xsl:output method="text" indent="yes"/><xsl:template match="root"><root>{
    "MontoActivos": "<xsl:value-of select="MontoActivos"/>",
    "GastosMensuales": "<xsl:value-of select="GastosMensuales"/>",
    "Table":
    [<xsl:for-each select="Table/FormEditResponse/TableSprintReview">
        {
        "NombreSocio": "<xsl:value-of select="TabAccionista/NombreSocio"/>",
        "Participacion": "<xsl:value-of select="TabAccionista/Participacion"/>",
        "TipoDocumento": ["<xsl:value-of select="TabAccionista/TipoDocumentoDemo"/>"]
        },
    </xsl:for-each>
    ],
    }</root></xsl:template></xsl:stylesheet>