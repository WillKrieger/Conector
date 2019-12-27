<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output indent="yes" method="xml"/>
    <xsl:template match="/">
        <root>
            <Nombre/>
            <Calle/>
            <Colonia/>
            <CodigoPostal/>
            <Estado/>
            <Municipio/>
            <Ciudad/>
            <ObservacionesAsesor>
                <xsl:value-of select="Root/values/ConAprAna"/>
            </ObservacionesAsesor>
            <SugerenciaAsesor>
                <xsl:value-of select="Root/values/IdeDes[1]"/>
            </SugerenciaAsesor>
        </root>
    </xsl:template>
</xsl:stylesheet>