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
            <ComentarioNegocio>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/ComentarioNegocio"/>&quot;
                <xsl:if test="string-length(Root/comments/ComentarioNegocio) &gt;0">
                    , &quot;comments&quot;: <xsl:value-of select="Root/comments/ComentarioNegocio"/></xsl:if>}
            </ComentarioNegocio>
            <NegEnDom>{ &quot;value&quot;:&quot;<xsl:if test="Root/values/NegocioEnDomicilio = 'true'"><xsl:text>Si</xsl:text></xsl:if><xsl:if test="Root/values/NegocioEnDomicilio = 'false'"><xsl:text>No</xsl:text></xsl:if>&quot;
                <xsl:if test="string-length(Root/comments/NegocioEnDomicilio) &gt;0">
                    , &quot;comments&quot;:<xsl:value-of select="Root/comments/NegocioEnDomicilio"/></xsl:if>}
            </NegEnDom>
            <NomSecEco>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/ActividadSector[1]"/>&quot;
                <xsl:if test="string-length(Root/comments/ActividadSector[1]) &gt;0">
                    , &quot;comments&quot;:
                    <xsl:value-of select="Root/comments/ActividadSector[1]"/></xsl:if>}
            </NomSecEco>
            <TipoNeg>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/TipoNegocio"/>&quot;
                <xsl:if test="string-length(Root/comments/TipoNegocio) &gt;0">
                    , &quot;comments&quot;:
                    <xsl:value-of select="Root/comments/TipoNegocio"/></xsl:if>}
            </TipoNeg>
            <NomActEco>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/ActividadSector[2]"/>&quot;
                <xsl:if test="string-length(Root/comments/ActividadSector[2]) &gt;0">
                    , &quot;comments&quot;:
                    <xsl:value-of select="Root/comments/ActividadSector[2]"/></xsl:if>}
            </NomActEco>
            <NombreNeg>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/NombreNegocio"/>&quot;
                <xsl:if test="string-length(Root/comments/NombreNegocio) &gt;0">, 
                    &quot;comments&quot;:<xsl:value-of select="Root/comments/NombreNegocio"/></xsl:if>}
            </NombreNeg>
            <TiempoExpNeg>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/TiempoExperiencia"/>&quot;
                <xsl:if test="string-length(Root/comments/TiempoExperiencia) &gt;0">
                    , &quot;comments&quot;:
                    <xsl:value-of select="Root/comments/TiempoExperiencia"/></xsl:if>}
            </TiempoExpNeg>
            <TiempoOpeNeg>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/TiempoOperacion"/>&quot;
                <xsl:if test="string-length(Root/comments/TiempoOperacion) &gt;0">
                    , &quot;comments&quot;:
                    <xsl:value-of select="Root/comments/TiempoOperacion"/></xsl:if>}
            </TiempoOpeNeg>
            <InscCamComercio>{ &quot;value&quot;:&quot;<xsl:if test="Root/values/InscritoCamaraComercio = 'true'"><xsl:text>Si</xsl:text></xsl:if><xsl:if test="Root/values/InscritoCamaraComercio = 'false'"><xsl:text>No</xsl:text></xsl:if>&quot;
                <xsl:if test="string-length(Root/comments/InscritoCamaraComercio) &gt;0">
                    , &quot;comments&quot;:
                    <xsl:value-of select="Root/comments/InscritoCamaraComercio"/></xsl:if>}
            </InscCamComercio>
            <NumEmpleadoFij>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/EmpleadosFijos"/>&quot;
                <xsl:if test="string-length(Root/comments/EmpleadosFijos) &gt;0">
                    , &quot;comments&quot;:
                    <xsl:value-of select="Root/comments/EmpleadosFijos"/></xsl:if>}</NumEmpleadoFij>
            <NumEmpleadoTem>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/EmpleadosTemporales"/>&quot;
                <xsl:if test="string-length(Root/comments/EmpleadosTemporales) &gt;0">
                    , &quot;comments&quot;:
                    <xsl:value-of select="Root/comments/EmpleadosTemporales"/></xsl:if>}</NumEmpleadoTem>
            <IngPromMens>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/IngresosMensuales"/>&quot;
                <xsl:if test="string-length(Root/comments/IngresosMensuales) &gt;0">
                    , &quot;comments&quot;:
                    <xsl:value-of select="Root/comments/IngresosMensuales"/></xsl:if>}</IngPromMens>
            <EgrPromMens>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/EgresosMensuales"/>&quot;
                <xsl:if test="string-length(Root/comments/EgresosMensuales) &gt;0">
                    , &quot;comments&quot;:
                    <xsl:value-of select="Root/comments/EgresosMensuales"/></xsl:if>}</EgrPromMens>
            <InfoLugTra>
                <FormEditResponse>
                    <InformacionNeg>
                        <SubForm1>
                            <DirNeg>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/DireccionNegocio"/>&quot;
                                <xsl:if test="string-length(Root/comments/DireccionNegocio) &gt;0">
                                    , &quot;comments&quot;:
                                    <xsl:value-of select="Root/comments/DireccionNegocio"/></xsl:if>}</DirNeg>
                            <RefUbiNeg>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/ReferenciaUbicacion"/>&quot;
                                <xsl:if test="string-length(Root/comments/ReferenciaUbicacion) &gt;0">
                                    , &quot;comments&quot;:
                                    <xsl:value-of select="Root/comments/ReferenciaUbicacion"/></xsl:if>}</RefUbiNeg>
                            <TelNeg>{ &quot;value&quot;:&quot;<xsl:value-of select="Root/values/TelefonoNegocio"/>&quot;
                                <xsl:if test="string-length(Root/comments/TelefonoNegocio) &gt;0">
                                    , &quot;comments&quot;:
                                    <xsl:value-of select="Root/comments/TelefonoNegocio"/></xsl:if>}</TelNeg>
                        </SubForm1>
                    </InformacionNeg>
                </FormEditResponse>
            </InfoLugTra>
            <ActNeg>
                <FormEditResponse>
                    <xsl:apply-templates select="Root/values/Activos"/>
                </FormEditResponse>
            </ActNeg>
        </root>
    </xsl:template>
    <xsl:template match="Root/values/Activos">
        <xsl:variable name="vPosition" select="position()"/>
        <ActivosNeg>
            <ActivosNeg>
                <TipoActivo>{ &quot;value&quot;:&quot;<xsl:value-of select="TipoActivo"/>&quot;
                   </TipoActivo>
                <DescActivo>{ &quot;value&quot;:&quot;<xsl:value-of select="DescripcionActivo"/>&quot;
                    <xsl:if test="string-length(//Root/comments/Activos[$vPosition]/DescripcionActivo) &gt;0">
                        , &quot;comments&quot;:
                        <xsl:value-of select="//Root/comments/Activos[$vPosition]/DescripcionActivo"/></xsl:if>}</DescActivo>
                <ValorAnt>{ &quot;value&quot;:&quot;<xsl:value-of select="ValorAnterior"/>&quot;
                    <xsl:if test="string-length(//Root/comments/Activos[$vPosition]/ValorAnterior) &gt;0">
                        , &quot;comments&quot;:
                        <xsl:value-of select="//Root/comments/Activos[$vPosition]/ValorAnterior"/></xsl:if>}</ValorAnt>
                <ValorAct>{ &quot;value&quot;:&quot;<xsl:value-of select="ValorActual"/>&quot;
                    <xsl:if test="string-length(//Root/comments/Activos[$vPosition]/ValorActual) &gt;0">
                        , &quot;comments&quot;:
                        <xsl:value-of select="//Root/comments/Activos[$vPosition]/ValorActual"/></xsl:if>}</ValorAct>
                <FechAdq>{ &quot;value&quot;:&quot;<xsl:value-of select="FechaAdquisicion"/>&quot;
                    <xsl:if test="string-length(//Root/comments/Activos[$vPosition]/FechaAdquisicion) &gt;0">
                        , &quot;comments&quot;:
                        <xsl:value-of select="//Root/comments/Activos[$vPosition]/FechaAdquisicion"/></xsl:if>}</FechAdq>
                <OrigenAct>{ &quot;value&quot;:&quot;<xsl:value-of select="OrigenActivo"/>&quot;
                    <xsl:if test="string-length(//Root/comments/Activos[$vPosition]/OrigenActivo) &gt;0">
                        , &quot;comments&quot;:
                        <xsl:value-of select="//Root/comments/Activos[$vPosition]/OrigenActivo"/></xsl:if>}</OrigenAct>
                <ValorCom>{ &quot;value&quot;:&quot;<xsl:value-of select="ValorComercial"/>&quot;
                    <xsl:if test="string-length(//Root/comments/Activos[$vPosition]/ValorComercial) &gt;0">
                        , &quot;comments&quot;:
                        <xsl:value-of select="//Root/comments/Activos[$vPosition]/ValorComercial"/></xsl:if>}</ValorCom>
                <Valorizacion>{ &quot;value&quot;:&quot;<xsl:value-of select="Valorizacion"/>&quot;
                    <xsl:if test="string-length(//Root/comments/Activos[$vPosition]/Valorizacion) &gt;0">
                        , &quot;comments&quot;:
                        <xsl:value-of select="//Root/comments/Activos[$vPosition]/Valorizacion"/></xsl:if>}</Valorizacion>
            </ActivosNeg>
        </ActivosNeg>
    </xsl:template>
</xsl:stylesheet>