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
            <NombreNegocio>
                <xsl:value-of select="Root/values/NombreNegocio"/>
            </NombreNegocio>
            <DireccionNegocio>
                <xsl:value-of select="Root/values/BarrioNegocio/DireccionNegocio"/>
            </DireccionNegocio>
            <BarrioNegocio>
                <xsl:value-of select="Root/values/BarrioNegocio/DeptoMunicipioBarrioNegocio[3]"/>
            </BarrioNegocio>
            <CiudadNegocio>
                <xsl:value-of select="Root/values/BarrioNegocio/DeptoMunicipioBarrioNegocio[2]"/>
            </CiudadNegocio>
            <DepartamentoNegocio>
                <xsl:value-of select="Root/values/BarrioNegocio/DeptoMunicipioBarrioNegocio[1]"/>
            </DepartamentoNegocio>
            <Sector>
                <xsl:value-of select="Root/values/ConActEco[2]"/>
            </Sector>
            <Actividad>
                <xsl:value-of select="Root/values/ConActEco[1]"/>
            </Actividad>
            <FechaInicioNegocio>
                <xsl:value-of select="Root/values/FechaInicioNegocio"/>
            </FechaInicioNegocio>
            <Destino>
                <xsl:value-of select="Root/values/Destino[1]"/>
            </Destino>
            <FormaPago>
                <xsl:value-of select="Root/values/FormaPago[1]"/>
            </FormaPago>
            <Monto>
                <xsl:value-of select="Root/values/Monto"/>
            </Monto>
            <Plazo>
                <xsl:value-of select="Root/values/Plazo"/>
            </Plazo>
            <Producto>
                <xsl:value-of select="Root/values/Producto[1]"/>
            </Producto>
        </root>
    </xsl:template>
</xsl:stylesheet>