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
            <Ppi1_CuaMieTieHog>
                <xsl:value-of select="Root/values/Ppi1_CuaMieTieHog[1]"/>
            </Ppi1_CuaMieTieHog>
            <CanMieUniFam>
                <xsl:value-of select="Root/values/CanMieUniFam"/>
            </CanMieUniFam>
            <CanPerDepCli>
                <xsl:value-of select="Root/values/CanPerDepCli"/>
            </CanPerDepCli>
            <CanHijCli>
                <xsl:value-of select="Root/values/CanHijCli"/>
            </CanHijCli>
            <Ppi2_NinActAsiEsc>
                <xsl:value-of select="Root/values/Ppi2_NinActAsiEsc[1]"/>
            </Ppi2_NinActAsiEsc>
            <Ppi3_MieConNivEduAlt>
                <xsl:value-of select="Root/values/Ppi3_MieConNivEduAlt"/>
            </Ppi3_MieConNivEduAlt>
            <TipSegSoc>
                <xsl:value-of select="Root/values/TipSegSoc"/>
            </TipSegSoc>
            <TitFuePEP>
                <xsl:value-of select="Root/values/TitFuePEP"/>
            </TitFuePEP>
            <CarPubDesCli>
                <xsl:value-of select="Root/values/CarPubDesCli"/>
            </CarPubDesCli>
            <TitVictPosCon>
                <xsl:value-of select="Root/values/TitVictPosCon"/>
            </TitVictPosCon>
            <CueConCer>
                <xsl:value-of select="Root/values/CueConCer"/>
            </CueConCer>
            <Ppi4_MieHogTieTraCon>
                <xsl:value-of select="Root/values/Ppi4_MieHogTieTraCon"/>
            </Ppi4_MieHogTieTraCon>
            <Ppi5_MieHogObrEmp>
                <xsl:value-of select="Root/values/Ppi5_MieHogObrEmp"/>
            </Ppi5_MieHogObrEmp>
            <Ppi6_MieHogPatEmp>
                <xsl:value-of select="Root/values/Ppi6_MieHogPatEmp"/>
            </Ppi6_MieHogPatEmp>
            <AdiNegEsEmpCli>
                <xsl:value-of select="Root/values/AdiNegEsEmpCli"/>
            </AdiNegEsEmpCli>
            <NomEmpLabCli>
                <xsl:value-of select="Root/values/DatLabCli/NomEmpLabCli"/>
            </NomEmpLabCli>
            <AntVinEmp>
                <xsl:value-of select="Root/values/DatLabCli/AntVinEmp"/>
            </AntVinEmp>
            <DirEmp>
                <xsl:value-of select="Root/values/DatLabCli/Direccion/DirEmp"/>
            </DirEmp>
            <CarEmpLabCli>
                <xsl:value-of select="Root/values/DatLabCli/CarEmpLabCli"/>
            </CarEmpLabCli>
            <SalEmpLabCli>
                <xsl:value-of select="Root/values/DatLabCli/SalEmpLabCli"/>
            </SalEmpLabCli>
            <NomConEmpLabCli>
                <xsl:value-of select="Root/values/DatLabCli/NomConEmpLabCli"/>
            </NomConEmpLabCli>
            <TelConEmpLabCli>
                <xsl:value-of select="Root/values/DatLabCli/TelConEmpLabCli"/>
            </TelConEmpLabCli>
            <ObsConLabli>
                <xsl:value-of select="Root/values/DatLabCli/ObsConLabli"/>
            </ObsConLabli>
            <IdeDepEmpLabCli>
                <xsl:value-of select="Root/values/DatLabCli/Direccion/DepartamentoMunicipioBarrio[1]"/>
            </IdeDepEmpLabCli>
            <IdeMunEmpLabCli>
                <xsl:value-of select="Root/values/DatLabCli/Direccion/DepartamentoMunicipioBarrio[2]"/>
            </IdeMunEmpLabCli>
            <IdeBarEmpLabCli>
                <xsl:value-of select="Root/values/DatLabCli/Direccion/DepartamentoMunicipioBarrio[3]"/>
            </IdeBarEmpLabCli>
            <CarConEmpLabCli>
                <xsl:value-of select="Root/values/CarConEmpLabCli"/>
            </CarConEmpLabCli>
            <NumIdeCon>
                <xsl:value-of select="Root/values/IdentificacionConyuge/NumIdeConExtrangeria"/>
            </NumIdeCon>
            <TipIdeCon>
                <xsl:value-of select="Root/values/IdentificacionConyuge/TipIdeCon[1]"/>
            </TipIdeCon>
            <NumIdeConOri>
                <xsl:value-of select="Root/values/NumIdeConOri"/>
            </NumIdeConOri>
            <MenResConCon>
                <xsl:value-of select="Root/values/MenResConCon"/>
            </MenResConCon>
            <CodRieValLisConCon>
                <xsl:value-of select="Root/values/CodRieValLisConCon"/>
            </CodRieValLisConCon>
            <LisConValLisConCon>
                <xsl:value-of select="Root/values/LisConValLisConCon"/>
            </LisConValLisConCon>
            <AdvLisConCon>
                <xsl:value-of select="Root/values/AdvLisConCon"/>
            </AdvLisConCon>
            <PriNomCon>
                <xsl:value-of select="Root/values/Conyuge/PriNomCon"/>
            </PriNomCon>
            <SegNomCon>
                <xsl:value-of select="Root/values/Conyuge/SegNomCon"/>
            </SegNomCon>
            <PriApeCon>
                <xsl:value-of select="Root/values/Conyuge/PriApeCon"/>
            </PriApeCon>
            <SegApeCon>
                <xsl:value-of select="Root/values/Conyuge/SegApeCon"/>
            </SegApeCon>
            <FecNacCon>
                <xsl:value-of select="Root/values/Conyuge/FecNacCon"/>
            </FecNacCon>
            <GenCon>
                <xsl:value-of select="Root/values/Conyuge/GenCon[1]"/>
            </GenCon>
            <FirCreCon>
                <xsl:value-of select="Root/values/FirCreCon"/>
            </FirCreCon>
            <MotFirCreCon>
                <xsl:value-of select="Root/values/MotFirCreCon"/>
            </MotFirCreCon>
            <VisCenRieCon>
                <xsl:value-of select="Root/values/VisCenRieCon"/>
            </VisCenRieCon>
            <EjeConCenRieCon>
                <xsl:value-of select="Root/values/EjeConCenRieCon"/>
            </EjeConCenRieCon>
            <AprCenRieCon>
                <xsl:value-of select="Root/values/AprCenRieCon"/>
            </AprCenRieCon>
            <CauDenCenRieCon>
                <xsl:value-of select="Root/values/CauDenCenRieCon[1]"/>
            </CauDenCenRieCon>
            <ComCauNegCenRieCon>
                <xsl:value-of select="Root/values/ComCauNegCenRieCon"/>
            </ComCauNegCenRieCon>
            <FecExpIdeCon>
                <xsl:value-of select="Root/values/FecExpIdeCon"/>
            </FecExpIdeCon>
            <IdeDepExpDocCon>
                <xsl:value-of select="Root/values/NomDepExpDocCon[1]"/>
            </IdeDepExpDocCon>
            <IdeMunExpDocCon>
                <xsl:value-of select="Root/values/NomDepExpDocCon[2]"/>
            </IdeMunExpDocCon>
            <TelCon>
                <xsl:value-of select="Root/values/TelCon"/>
            </TelCon>
            <CelCon>
                <xsl:value-of select="Root/values/CelCon"/>
            </CelCon>
            <NivEduCon>
                <xsl:value-of select="Root/values/NivEduCon[1]"/>
            </NivEduCon>
            <ConFuePEP>
                <xsl:value-of select="Root/values/ConFuePEP"/>
            </ConFuePEP>
            <CarPubDesCon>
                <xsl:value-of select="Root/values/CarPubDesCon"/>
            </CarPubDesCon>
            <ActDelCon>
                <xsl:value-of select="Root/values/ActDelCon[1]"/>
            </ActDelCon>
            <MotNoActNegCon>
                <xsl:value-of select="Root/values/MotNoActNegCon"/>
            </MotNoActNegCon>
            <EmpLabCon>
                <xsl:value-of select="Root/values/EmpLabCon"/>
            </EmpLabCon>
            <AntVinEmpCon>
                <xsl:value-of select="Root/values/AntVinEmpCon"/>
            </AntVinEmpCon>
            <DirEmpLabCon>
                <xsl:value-of select="Root/values/DatEmpLabCon/DirEmpLabCon"/>
            </DirEmpLabCon>
            <IdeDepEmpLabCon>
                <xsl:value-of select="Root/values/DatEmpLabCon/DeptoMunicipioBarrioDomicilio[1]"/>
            </IdeDepEmpLabCon>
            <IdeMunEmpLabCon>
                <xsl:value-of select="Root/values/DatEmpLabCon/DeptoMunicipioBarrioDomicilio[2]"/>
            </IdeMunEmpLabCon>
            <IdeBarEmpLabCon>
                <xsl:value-of select="Root/values/DatEmpLabCon/DeptoMunicipioBarrioDomicilio[3]"/>
            </IdeBarEmpLabCon>
            <CarEmpLabCon>
                <xsl:value-of select="Root/values/CarEmpLabCon"/>
            </CarEmpLabCon>
            <SalEmpLabCon>
                <xsl:value-of select="Root/values/SalEmpLabCon"/>
            </SalEmpLabCon>
            <NomConEmpLabCon>
                <xsl:value-of select="Root/values/NomConEmpLabCon"/>
            </NomConEmpLabCon>
            <CarConEmpLabCon>
                <xsl:value-of select="Root/values/CarConEmpLabCon"/>
            </CarConEmpLabCon>
            <TelConEmpLabCon>
                <xsl:value-of select="Root/values/TelConEmpLabCon"/>
            </TelConEmpLabCon>
            <ObsConLabCon>
                <xsl:value-of select="Root/values/ObsConLabCon"/>
            </ObsConLabCon>
            <ObsGenCon>
                <xsl:value-of select="Root/values/ObsGenCon"/>
            </ObsGenCon>
            <TipVivCli>
                <xsl:value-of select="Root/values/TipVivCli[1]"/>
            </TipVivCli>
            <InfVivFam>
                <xsl:value-of select="Root/values/InfVivFam"/>
            </InfVivFam>
            <NomFamViv>
                <xsl:value-of select="Root/values/NomFamViv"/>
            </NomFamViv>
            <ParFamViv>
                <xsl:value-of select="Root/values/ParFamViv[1]"/>
            </ParFamViv>
            <CanArrCasFam>
                <xsl:value-of select="Root/values/CanArrCasFam"/>
            </CanArrCasFam>
            <ValArrCanFam>
                <xsl:value-of select="Root/values/ValArrCanFam"/>
            </ValArrCanFam>
            <TelFamArr>
                <xsl:value-of select="Root/values/TelFamArr"/>
            </TelFamArr>
            <LlaTelFamArr>
                <xsl:value-of select="Root/values/LlaTelFamArr"/>
            </LlaTelFamArr>
            <CelFamArr>
                <xsl:value-of select="Root/values/CelFamArr"/>
            </CelFamArr>
            <LlaCelFamArr>
                <xsl:value-of select="Root/values/LlaCelFamArr"/>
            </LlaCelFamArr>
            <ValTelFamArr>
                <xsl:value-of select="Root/values/ValTelFamArr"/>
            </ValTelFamArr>
            <ObsConArr>
                <xsl:value-of select="Root/values/ObsConArr"/>
            </ObsConArr>
            <TieResViv>
                <xsl:value-of select="Root/values/TieResViv"/>
            </TieResViv>
            <EsLegViv>
                <xsl:value-of select="Root/values/EsLegViv"/>
            </EsLegViv>
            <EstPreTit>
                <xsl:value-of select="Root/values/EstPreTit[1]"/>
            </EstPreTit>
            <FotRecPubTit>
                <xsl:value-of select="Root/values/EstPreTiFotRecPubTit"/>
            </FotRecPubTit>
            <TieMasBieInm>
                <xsl:value-of select="Root/values/TieMasBieInm"/>
            </TieMasBieInm>
            <CanBieInmAdi>
                <xsl:value-of select="Root/values/CanBieInmAdi"/>
            </CanBieInmAdi>
            <EsLegBieInmAdi>
                <xsl:value-of select="Root/values/EsLegBieInmAdi"/>
            </EsLegBieInmAdi>
            <BieInmAdiProFin>
                <xsl:value-of select="Root/values/BieInmAdiProFin"/>
            </BieInmAdiProFin>
            <NomArrViv>
                <xsl:value-of select="Root/values/NomArrViv"/>
            </NomArrViv>
            <ValArrViv>
                <xsl:value-of select="Root/values/ValArrViv"/>
            </ValArrViv>
            <TelArrViv>
                <xsl:value-of select="Root/values/TelArrViv"/>
            </TelArrViv>
            <CelArrViv>
                <xsl:value-of select="Root/values/ObsArrAct"/>
            </CelArrViv>
            <ObsArrAct>
                <xsl:value-of select="Root/values/ObsArrAct"/>
            </ObsArrAct>
            <AntVivArr>
                <xsl:value-of select="Root/values/AntVivArr"/>
            </AntVivArr>
            <NomArrAnt>
                <xsl:value-of select="Root/values/NomArrAnt"/>
            </NomArrAnt>
            <ValArrAnt>
                <xsl:value-of select="Root/values/ValArrAnt"/>
            </ValArrAnt>
            <TelArrAnt>
                <xsl:value-of select="Root/values/TelArrAnt"/>
            </TelArrAnt>
            <CelArrAnt>
                <xsl:value-of select="Root/values/CelArrAnt"/>
            </CelArrAnt>
            <ObsArrAnt>
                <xsl:value-of select="Root/values/ObsArrAnt"/>
            </ObsArrAnt>
            <CueAguPotViv>
                <xsl:value-of select="Root/values/CueAguPotViv"/>
            </CueAguPotViv>
            <CueAccInt>
                <xsl:value-of select="Root/values/CueAccInt"/>
            </CueAccInt>
            <DesDonCon>
                <xsl:value-of select="Root/values/DesDonCon[1]"/>
            </DesDonCon>
            <ReaTraMonExt>
                <xsl:value-of select="Root/values/ReaTraMonExt"/>
            </ReaTraMonExt>
            <IdeSecEcoMon>
                <xsl:value-of select="Root/values/IdeSecEcoMon[1]"/>
            </IdeSecEcoMon>
            <IdeActEcoMon>
                <xsl:value-of select="Root/values/IdeSecEcoMon[2]"/>
            </IdeActEcoMon>
            <TipMonCom>
                <xsl:value-of select="Root/values/TipMonCom[1]"/>
            </TipMonCom>
            <MonMenTra>
                <xsl:value-of select="Root/values/MonMenTra"/>
            </MonMenTra>
            <FecPosNeg>
                <xsl:value-of select="Root/values/FecPosNeg"/>
            </FecPosNeg>
            <FecExpNeg>
                <xsl:value-of select="Root/values/FecExpNeg"/>
            </FecExpNeg>
            <NumEmpFijNeg>
                <xsl:value-of select="Root/values/NumEmpFijNeg"/>
            </NumEmpFijNeg>
            <NumEmpTemNeg>
                <xsl:value-of select="Root/values/NumEmpTemNeg"/>
            </NumEmpTemNeg>
            <NumEmpNeg>
                <xsl:value-of select="Root/values/NumEmpNeg"/>
            </NumEmpNeg>
            <NegTieCamCom>
                <xsl:value-of select="Root/values/NegTieCamCom"/>
            </NegTieCamCom>
            <NegTieRut>
                <xsl:value-of select="Root/values/NegTieRut"/>
            </NegTieRut>
            <TipLocNeg>
                <xsl:value-of select="Root/values/TipLocNeg[1]"/>
            </TipLocNeg>
            <NomComArrNeg>
                <xsl:value-of select="Root/values/NomComArrNeg"/>
            </NomComArrNeg>
            <TelArrNeg>
                <xsl:value-of select="Root/values/TelArrNeg"/>
            </TelArrNeg>
            <CelArrNeg>
                <xsl:value-of select="Root/values/CelArrNeg"/>
            </CelArrNeg>
            <CanArrNeg>
                <xsl:value-of select="Root/values/CanArrNeg"/>
            </CanArrNeg>
            <FecFunLoc>
                <xsl:value-of select="Root/values/FecFunLoc"/>
            </FecFunLoc>
            <ValFecPosLoc>
                <xsl:value-of select="Root/values/ValFecPosLoc"/>
            </ValFecPosLoc>
            <ObsArrLoc>
                <xsl:value-of select="Root/values/ObsArrLoc"/>
            </ObsArrLoc>
            <NomVerZonCom>
                <xsl:value-of select="Root/values/NomVerZonCom"/>
            </NomVerZonCom>
            <DirVerZonCom>
                <xsl:value-of select="Root/values/DirVerZonCom"/>
            </DirVerZonCom>
            <TelVerZonCom>
                <xsl:value-of select="Root/values/TelVerZonCom"/>
            </TelVerZonCom>
            <ZonTieActEco>
                <xsl:value-of select="Root/values/ZonTieActEco"/>
            </ZonTieActEco>
            <IdeSecRefZon>
                <xsl:value-of select="Root/values/IdeSecRefZon[1]"/>
            </IdeSecRefZon>
            <IdeActRefZon>
                <xsl:value-of select="Root/values/IdeSecRefZon[2]"/>
            </IdeActRefZon>
            <EsCliVigVerZonCom>
                <xsl:value-of select="Root/values/EsCliVigVerZonCom"/>
            </EsCliVigVerZonCom>
            <EstIntCreVerZonCom>
                <xsl:value-of select="Root/values/EstIntCreVerZonCom[1]"/>
            </EstIntCreVerZonCom>
            <ProVisVerZonCom>
                <xsl:value-of select="Root/values/ProVisVerZonCom"/>
            </ProVisVerZonCom>
            <ObsVerZonCom>
                <xsl:value-of select="Root/values/ObsVerZonCom"/>
            </ObsVerZonCom>
            <EstDelNeg>
                <xsl:value-of select="Root/values/EstDelNeg[1]"/>
            </EstDelNeg>
            <CanTitIguViv>
                <xsl:value-of select="Root/values/CanTitIguViv"/>
            </CanTitIguViv>
            <CuoMenPuePag>
                <xsl:value-of select="Root/values/CuoMenPuePag"/>
            </CuoMenPuePag>
            <ProAhoMen>
                <xsl:value-of select="Root/values/ProAhoMen"/>
            </ProAhoMen>
            <ComAnaCre>
                <xsl:value-of select="Root/values/ComAnaCre"/>
            </ComAnaCre>
        </root>
    </xsl:template>
</xsl:stylesheet>