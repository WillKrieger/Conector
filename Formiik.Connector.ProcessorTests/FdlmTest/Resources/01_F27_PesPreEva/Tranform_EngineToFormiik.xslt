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
            <VisAyu>
                <xsl:value-of select="Root/values/VisAyu"/>
            </VisAyu>
            <NumDocIdeCli>
                <xsl:value-of select="Root/values/Identificacion/NumDocIdeCliCiudadania"/>
            </NumDocIdeCli>
            <TipDocIdeCli>
                <xsl:value-of select="Root/values/Identificacion/TipDocIdeCli[1]"/>
            </TipDocIdeCli>
            <PaiExpCli>
                <xsl:value-of select="Root/values/Identificacion/PaiExpCli[1]"/>
            </PaiExpCli>
            <NumSolCre>
                <xsl:value-of select="Root/values/NumSolCre"/>
            </NumSolCre>
            <DesCarInfCli>
                <xsl:value-of select="Root/values/DesCarInfCli"/>
            </DesCarInfCli>
            <MenResConCliSol>
                <xsl:value-of select="Root/values/MenResConCliSol"/>
            </MenResConCliSol>
            <CodRieValLisConCli>
                <xsl:value-of select="Root/values/CodRieValLisConCli"/>
            </CodRieValLisConCli>
            <LisConValLisConCli>
                <xsl:value-of select="Root/values/LisConValLisConCli"/>
            </LisConValLisConCli>
            <AdvLisConCli>
                <xsl:value-of select="Root/values/AdvLisConCli"/>
            </AdvLisConCli>
            <CalCli>
                <xsl:value-of select="Root/values/CalCli"/>
            </CalCli>
            <PriNomCli>
                <xsl:value-of select="Root/values/Titular/PriNomCli"/>
            </PriNomCli>
            <SegNomCli>
                <xsl:value-of select="Root/values/Titular/SegNomCli"/>
            </SegNomCli>
            <PriApeCli>
                <xsl:value-of select="Root/values/Titular/PriApeCli"/>
            </PriApeCli>
            <SegApeCli>
                <xsl:value-of select="Root/values/Titular/SegApeCli"/>
            </SegApeCli>
            <RutForUltCre>
                <xsl:value-of select="Root/values/RutForUltCre"/>
            </RutForUltCre>
            <TelDomCli>
                <xsl:value-of select="Root/values/TelDomCli"/>
            </TelDomCli>
            <CelPerCli>
                <xsl:value-of select="Root/values/CelPerCli"/>
            </CelPerCli>
            <TelNegCli>
                <xsl:value-of select="Root/values/TelNegCli"/>
            </TelNegCli>
            <CelNegCli>
                <xsl:value-of select="Root/values/CelNegCli"/>
            </CelNegCli>
            <NegEnDom>
                <xsl:value-of select="Root/values/NegEnDom"/>
            </NegEnDom>
            <DirDomCli>
                <xsl:value-of select="Root/values/LocalizacionDomicilioTitular/DirDomCli"/>
            </DirDomCli>
            <IndDirDomCli>
                <xsl:value-of select="Root/values/LocalizacionDomicilioTitular/IndDirDomCli"/>
            </IndDirDomCli>
            <UbiDomCli>
                <xsl:value-of select="Root/values/LocalizacionDomicilioTitular/UbiDomCli"/>
            </UbiDomCli>
            <IdeBarDomCli>
                <xsl:value-of select="Root/values/LocalizacionDomicilioTitular/DeptoMunicipioBarrioDomicilio[3]"/>
            </IdeBarDomCli>
            <IdeMunBarDomCli>
                <xsl:value-of select="Root/values/LocalizacionDomicilioTitular/DeptoMunicipioBarrioDomicilio[2]"/>
            </IdeMunBarDomCli>
            <IdeDepBarDomCli>
                <xsl:value-of select="Root/values/LocalizacionDomicilioTitular/DeptoMunicipioBarrioDomicilio[1]"/>
            </IdeDepBarDomCli>
            <TipNeg>
                <xsl:value-of select="Root/values/TipNeg[1]"/>
            </TipNeg>
            <DirNegCli>
                <xsl:value-of select="Root/values/LocalizacionNegocioTitular/DirNegCli"/>
            </DirNegCli>
            <IndDirNegCli>
                <xsl:value-of select="Root/values/LocalizacionNegocioTitular/IndDirNegCli"/>
            </IndDirNegCli>
            <UbiNegCli>
                <xsl:value-of select="Root/values/LocalizacionNegocioTitular/UbiNegCli"/>
            </UbiNegCli>
            <IdeBarNegCli>
                <xsl:value-of select="Root/values/LocalizacionNegocioTitular/DeptoMunicipioBarrioNegocio[3]"/>
            </IdeBarNegCli>
            <IdeMunBarNegCli>
                <xsl:value-of select="Root/values/LocalizacionNegocioTitular/DeptoMunicipioBarrioNegocio[2]"/>
            </IdeMunBarNegCli>
            <IdeDepBarNegCli>
                <xsl:value-of select="Root/values/LocalizacionNegocioTitular/DeptoMunicipioBarrioNegocio[1]"/>
            </IdeDepBarNegCli>
            <HaPadSigEnf>
                <xsl:value-of select="Root/values/HaPadSigEnf"/>
            </HaPadSigEnf>
            <HaPadLimFis>
                <xsl:value-of select="Root/values/HaPadLimFis"/>
            </HaPadLimFis>
            <CumReqMin>
                <xsl:value-of select="Root/values/CumReqMin"/>
            </CumReqMin>
            <CauDenPreEva>
                <xsl:value-of select="Root/values/CauDenPreEva[1]"/>
            </CauDenPreEva>
            <ComCauDenPreEva>
                <xsl:value-of select="Root/values/ComCauDenPreEva"/>
            </ComCauDenPreEva>
            <LleSolOtroMom>
                <xsl:value-of select="Root/values/LleSolOtroMom"/>
            </LleSolOtroMom>
            <FecProVis>
                <xsl:value-of select="Root/values/FecProVis"/>
            </FecProVis>
        </root>
    </xsl:template>
</xsl:stylesheet>