<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
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
            <NombreNegocio>
                <xsl:value-of select="Root/values/NombreNegocio"/>
            </NombreNegocio>
            <CalleYNumeroNegocio>
                <xsl:value-of select="Root/values/LocalizacionDomicilioNegocio/CalleYNumero"/>
            </CalleYNumeroNegocio>
            <DeptoMunicipioBarrioNegocio0ID>
                <xsl:value-of select="Root/values/LocalizacionDomicilioNegocio/DeptoMunicipioBarrioNegocio[3]"/>
            </DeptoMunicipioBarrioNegocio0ID>
            <DeptoMunicipioBarrioNegocio1ID>
                <xsl:value-of select="Root/values/LocalizacionDomicilioNegocio/DeptoMunicipioBarrioNegocio[2]"/>
            </DeptoMunicipioBarrioNegocio1ID>
            <DeptoMunicipioBarrioNegocio2ID>
                <xsl:value-of select="Root/values/LocalizacionDomicilioNegocio/DeptoMunicipioBarrioNegocio[1]"/>
            </DeptoMunicipioBarrioNegocio2ID>
            <Antiguedad>
                <xsl:value-of select="Root/values/Antiguedad"/>
            </Antiguedad>
        </root>
    </xsl:template>
</xsl:stylesheet>