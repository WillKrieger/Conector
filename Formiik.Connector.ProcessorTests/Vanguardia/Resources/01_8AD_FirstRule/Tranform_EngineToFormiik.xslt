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
            <xsl:if test = "Root/values/EsMayorEdad = 'true'">
                <EsMayorEdad><xsl:text>Si</xsl:text></EsMayorEdad>
            </xsl:if>
            <xsl:if test = "Root/values/EsMayorEdad = 'false'">
                <EsMayorEdad><xsl:text>No</xsl:text></EsMayorEdad>
            </xsl:if>
            <xsl:if test = "Root/values/TieneNegocio = 'true'">
                <TieneNegocio><xsl:text>Si</xsl:text></TieneNegocio>
            </xsl:if>
            <xsl:if test = "Root/values/TieneNegocio = 'false'">
                <TieneNegocio><xsl:text>No</xsl:text></TieneNegocio>
            </xsl:if>
            <xsl:if test = "Root/values/TiempoNegocioRequerido = 'true'">
                <TiempoNegocioRequerido><xsl:text>Si</xsl:text></TiempoNegocioRequerido>
            </xsl:if>
            <xsl:if test = "Root/values/TiempoNegocioRequerido = 'false'">
                <TiempoNegocioRequerido><xsl:text>No</xsl:text></TiempoNegocioRequerido>
            </xsl:if>
            <TipoDocumento>
                <xsl:value-of select="Root/values/TipoDocumento[1]"/>
            </TipoDocumento>
            <NumeroDocumento>
                <xsl:value-of select="Root/values/NumeroDocumento"/>
            </NumeroDocumento>
            <PrimerApellido>
                <xsl:value-of select="Root/values/PrimerApellido"/>
            </PrimerApellido>
            <SegundoApellido>
                <xsl:value-of select="Root/values/SegundoApellido"/>
            </SegundoApellido>
            <PrimerNombre>
                <xsl:value-of select="Root/values/PrimerNombre"/>
            </PrimerNombre>
            <SegundoNombre>
                <xsl:value-of select="Root/values/SegundoNombre"/>
            </SegundoNombre>
            <FechaNacimiento>
                <xsl:value-of select="Root/values/FechaNacimiento"/>
            </FechaNacimiento>
            <EstadoCivil>
                <xsl:value-of select="Root/values/EstadoCivil[1]"/>
            </EstadoCivil>
            <DireccionResidencia>
                <xsl:value-of select="Root/values/BarrioResidencia/DireccionResidencia"/>
            </DireccionResidencia>
            <BarrioResidencia>
                <xsl:value-of select="Root/values/BarrioResidencia/DeptoMunicipioBarrioDomicilio[3]"/>
            </BarrioResidencia>
            <CiudadResidencia>
                <xsl:value-of select="Root/values/BarrioResidencia/DeptoMunicipioBarrioDomicilio[2]"/>
            </CiudadResidencia>
            <DepartamentoResidencia>
                <xsl:value-of select="Root/values/BarrioResidencia/DeptoMunicipioBarrioDomicilio[1]"/>
            </DepartamentoResidencia>
            <Telefono>
                <xsl:value-of select="Root/values/Telefono"/>
            </Telefono>
            <Celular>
                <xsl:value-of select="Root/values/Celular"/>
            </Celular>
        </root>
    </xsl:template>
</xsl:stylesheet>