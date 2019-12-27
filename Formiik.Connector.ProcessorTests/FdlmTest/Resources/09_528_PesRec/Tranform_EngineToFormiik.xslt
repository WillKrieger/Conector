<?xml version="1/0" encoding="utf-8"?>
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
            <ProyNroCreGenExt>
                <xsl:value-of select="Root/values/ProyNroCreGenExt"/>
            </ProyNroCreGenExt>
            <ValCuoyPerUltCreDes>
                <xsl:value-of select="Root/values/ValCuoyPerUltCreDes"/>
            </ValCuoyPerUltCreDes>
            <ReaConIntSol>
                <xsl:value-of select="Root/values/ReaConIntSol"/>
            </ReaConIntSol>
            <ProSug>
                <xsl:value-of select="Root/values/ProSug[0]"/>
            </ProSug>
            <DesCre>
                <xsl:value-of select="Root/values/ProSug[1]"/>
            </DesCre>
            <MonSug>
                <xsl:value-of select="Root/values/MonSug"/>
            </MonSug>
            <PerSug>
                <xsl:value-of select="Root/values/PerSug"/>
            </PerSug>
            <PlaSug>
                <xsl:value-of select="Root/values/PlaSug"/>
            </PlaSug>
            <CuoMaxRec>
                <xsl:value-of select="Root/values/CuoMaxRec"/>
            </CuoMaxRec>
            <ReqCorInfDil>
                <xsl:value-of select="Root/values/ReqCorInfDil"/>
            </ReqCorInfDil>
            <MenResConRut>
                <xsl:value-of select="Root/values/MenResConRut"/>
            </MenResConRut>
            <ValCuoRec>
                <xsl:value-of select="Root/values/ValCuoRec"/>
            </ValCuoRec>
            <ValTotPolOfrCli>
                <xsl:value-of select="Root/values/ValTotPolOfrCli"/>
            </ValTotPolOfrCli>
            <RutFor>
                <xsl:value-of select="Root/values/RutFor"/>
            </RutFor>
            <RecEva>
                <xsl:value-of select="Root/values/RecEva[0]"/>
            </RecEva>
            <CauDenEva>
                <xsl:value-of select="Root/values/CauDenEva[0]"/>
            </CauDenEva>
            <DesAgeNueVis>
                <xsl:value-of select="Root/values/DesAgeNueVis"/>
            </DesAgeNueVis>
            <FecProVis>
                <xsl:value-of select="Root/values/FecProVis"/>
            </FecProVis>
            <ObsRecEva>
                <xsl:value-of select="Root/values/ObsRecEva"/>
            </ObsRecEva>
            <ParRef>
                <xsl:value-of select="Root/values/Parentesco[0]"/>
            </ParRef>
            <ParRef>
                <xsl:value-of select="Root/values/Parentesco[0]"/>
            </ParRef>
            <DirRef>
                <xsl:value-of select="Root/values/Location/Direccion"/>
            </DirRef>
            <DirRef>
                <xsl:value-of select="Root/values/Location/Direccion"/>
            </DirRef>
            <DirRefCom>
                <xsl:value-of select="Root/values/Location/Direccion"/>
            </DirRefCom>
            <DirNegRef>
                <xsl:value-of select="Root/values/Location/Direccion"/>
            </DirNegRef>
            <TelRef>
                <xsl:value-of select="Root/values/Contact/TelefonoLocal"/>
            </TelRef>
            <CelRef>
                <xsl:value-of select="Root/values/Contact/TelefonoCelular"/>
            </CelRef>
            <TelRef>
                <xsl:value-of select="Root/values/Contact/TelefonoLocal"/>
            </TelRef>
            <CelRef>
                <xsl:value-of select="Root/values/Contact/TelefonoCelular"/>
            </CelRef>
            <TelRefCom>
                <xsl:value-of select="Root/values/Contact/TelefonoLocal"/>
            </TelRefCom>
            <CelRefCom>
                <xsl:value-of select="Root/values/Contact/TelefonoCelular"/>
            </CelRefCom>
            <TelRec>
                <xsl:value-of select="Root/values/Contact/TelefonoLocal"/>
            </TelRec>
            <CelRec>
                <xsl:value-of select="Root/values/Contact/TelefonoCelular"/>
            </CelRec>
            <TelCod>
                <xsl:value-of select="Root/values/Contact/TelefonoLocal"/>
            </TelCod>
            <CelCod>
                <xsl:value-of select="Root/values/Contact/TelefonoCelular"/>
            </CelCod>
                <xsl:value-of select="Root/values/Engine"/>
            </Mobile>
            <ForPagRefCom>
                <xsl:value-of select="Root/values/FormaPago[0]"/>
            </ForPagRefCom>
            <EntBanRefBan>
                <xsl:value-of select="Root/values/EntidadBanco[0]"/>
            </EntBanRefBan>
            <ProRefBan>
                <xsl:value-of select="Root/values/Producto[0]"/>
            </ProRefBan>
            <PriNomRef>
                <xsl:value-of select="Root/values/Subject/Person/PrimerNombre"/>
            </PriNomRef>
            <SegNomRef>
                <xsl:value-of select="Root/values/Subject/Person/SegundoNombre"/>
            </SegNomRef>
            <PriApeRef>
                <xsl:value-of select="Root/values/Subject/Person/PrimerApellido"/>
            </PriApeRef>
            <SegApeRef>
                <xsl:value-of select="Root/values/Subject/Person/SegundoApellido"/>
            </SegApeRef>
            <NumDocIdeRef>
                <xsl:value-of select="Root/values/Subject/Person/Id/NumeroDocCiudadania"/>
            </NumDocIdeRef>
            <TipDocIdeRef>
                <xsl:value-of select="Root/values/Subject/Person/Id//TipoDocumento[0]"/>
            </TipDocIdeRef>
            <PaiOriRef>
                <xsl:value-of select="Root/values/Subject/Person/Id//PaisExpedicion[0]"/>
            </PaiOriRef>
            <IdeActNegRef>
                <xsl:value-of select="Root/values/ActividadSector[0]"/>
            </IdeActNegRef>
            <NumDocIdeCod>
                <xsl:value-of select="Root/values/Id/NumDocIdeCliCiudadania"/>
            </NumDocIdeCod>
            <TipDocIdeCod>
                <xsl:value-of select="Root/values/Id/TipoDocumento[0]"/>
            </TipDocIdeCod>
            <IdeDepExpDocIdeCod>
                <xsl:value-of select="Root/values/Id/DepartamentoMunicipioBarrioExpedicion[0]"/>
            </IdeDepExpDocIdeCod>
            <IdeMunExpDocIdeCod>
                <xsl:value-of select="Root/values/Id/DepartamentoMunicipioBarrioExpedicion[2]"/>
            </IdeMunExpDocIdeCod>
            <PriNomCod>
                <xsl:value-of select="Root/values/Subject/Person/PrimerNombre"/>
            </PriNomCod>
            <SegNomCod>
                <xsl:value-of select="Root/values/Subject/Person/SegundoNombre"/>
            </SegNomCod>
            <PriApeCod>
                <xsl:value-of select="Root/values/Subject/Person/PrimerApellido"/>
            </PriApeCod>
            <SegApeCod>
                <xsl:value-of select="Root/values/Subject/Person/SegundoApellido"/>
            </SegApeCod>
            <NomBenTuHij>
                <xsl:value-of select="Root/values/Subject/Person/PrimerNombre"/>
            </NomBenTuHij>
            <PriApeBenTuHij>
                <xsl:value-of select="Root/values/Subject/Person/PrimerApellido"/>
            </PriApeBenTuHij>
            <SegApeBenTuHij>
                <xsl:value-of select="Root/values/Subject/Person/SegundoApellido"/>
            </SegApeBenTuHij>
            <NomBen>
                <xsl:value-of select="Root/values/Subject/Person/PrimerNombre"/>
            </NomBen>
            <PriApeBen>
                <xsl:value-of select="Root/values/Subject/Person/PrimerApellido"/>
            </PriApeBen>
            <SegApeBen>
                <xsl:value-of select="Root/values/Subject/Person/SegundoApellido"/>
            </SegApeBen>
            <FecNacBen>
                <xsl:value-of select="Root/values/Subject/Person/FechaNacimiento"/>
            </FecNacBen>
            <NomBenAuxInm>
                <xsl:value-of select="Root/values/Subject/Person/PrimerNombre"/>
            </NomBenAuxInm>
            <PriApeBenAuxInm>
                <xsl:value-of select="Root/values/Subject/Person/PrimerApellido"/>
            </PriApeBenAuxInm>
            <SegApeBenAuxInm>
                <xsl:value-of select="Root/values/Subject/Person/SegundoApellido"/>
            </SegApeBenAuxInm>
            <NomBenVid>
                <xsl:value-of select="Root/values/Subject/Person/PrimerNombre"/>
            </NomBenVid>
            <PriApeBenVid>
                <xsl:value-of select="Root/values/Subject/Person/PrimerApellido"/>
            </PriApeBenVid>
            <SegApeBenVid>
                <xsl:value-of select="Root/values/Subject/Person/SegundoApellido"/>
            </SegApeBenVid>
            <NomBenVid>
                <xsl:value-of select="Root/values/Subject/Person/PrimerNombre"/>
            </NomBenVid>
            <PriApeBenVid>
                <xsl:value-of select="Root/values/Subject/Person/PrimerApellido"/>
            </PriApeBenVid>
            <SegApeBenVid>
                <xsl:value-of select="Root/values/Subject/Person/SegundoApellido"/>
            </SegApeBenVid>
            <GenCod>
                <xsl:value-of select="Root/values/Subject/Person/Genero[0]"/>
            </GenCod>
            <GenBen>
                <xsl:value-of select="Root/values/Subject/Person/Genero[0]"/>
            </GenBen>
            <EstCivCod>
                <xsl:value-of select="Root/values/Subject/Person/EstadoCivil[0]"/>
            </EstCivCod>
            <DirDomCod>
                <xsl:value-of select="Root/values/DomicilioLocation/Direccion"/>
            </DirDomCod>
            <IdeDepDomCod>
                <xsl:value-of select="Root/values/DomicilioLocation/DepartamentoMunicipioBarrio[0]"/>
            </IdeDepDomCod>
            <IdeMunDomCod>
                <xsl:value-of select="Root/values/DomicilioLocation/DepartamentoMunicipioBarrio[1]"/>
            </IdeMunDomCod>
            <IdeBarDomCod>
                <xsl:value-of select="Root/values/DomicilioLocation/DepartamentoMunicipioBarrio[2]"/>
            </IdeBarDomCod>
            <ParTitCod>
                <xsl:value-of select="Root/values/Subject/Parentesco[0]"/>
            </ParTitCod>
            <ParBen>
                <xsl:value-of select="Root/values/Subject/Parentesco[0]"/>
            </ParBen>
            <ParBenAuxInm>
                <xsl:value-of select="Root/values/Subject/Parentesco[0]"/>
            </ParBenAuxInm>
            <ParBenVid>
                <xsl:value-of select="Root/values/Subject/Parentesco[0]"/>
            </ParBenVid>
            <ParBenVid>
                <xsl:value-of select="Root/values/Subject/Parentesco[0]"/>
            </ParBenVid>
            <TipVivCod>
                <xsl:value-of select="Root/values/TipoVivienda[0]"/>
            </TipVivCod>
            <TelArrVivCod>
                <xsl:value-of select="Root/values/ContactArrendador/TelefonoLocal"/>
            </TelArrVivCod>
            <CelArrVivCod>
                <xsl:value-of select="Root/values/ContactArrendador/TelefonoCelular"/>
            </CelArrVivCod>
            <NomComRefCod>
                <xsl:value-of select="Root/values/ReferenciaCodeudor/Nombre"/>
            </NomComRefCod>
            <OcuRefCod>
                <xsl:value-of select="Root/values/ReferenciaCodeudor/Ocupacion"/>
            </OcuRefCod>
            <ActEcoIndRef>
                <xsl:value-of select="Root/values/ReferenciaCodeudor/ActividadIndependiente"/>
            </ActEcoIndRef>
            <EstIntCreRefCod>
                <xsl:value-of select="Root/values/ReferenciaCodeudor/Interesado"/>
            </EstIntCreRefCod>
            <ProVisRefCod>
                <xsl:value-of select="Root/values/ReferenciaCodeudor/ProgramacionVisita"/>
            </ProVisRefCod>
            <ParRefCod>
                <xsl:value-of select="Root/values/ReferenciaCodeudor/Parentesco[0]"/>
            </ParRefCod>
            <IdeSecNegCod>
                <xsl:value-of select="Root/values/ReferenciaCodeudor/ActividadSector[0]"/>
            </IdeSecNegCod>
            <IdeActEcoCod>
                <xsl:value-of select="Root/values/ReferenciaCodeudor/ActividadSector[1]"/>
            </IdeActEcoCod>
            <DirRefCod>
                <xsl:value-of select="Root/values/RefrenciaCodeudor/Location/Direccion"/>
            </DirRefCod>
            <TelRefCod>
                <xsl:value-of select="Root/values/ReferenciaCodeudor/Contact/TelefonoLocal"/>
            </TelRefCod>
            <CelRefCod>
                <xsl:value-of select="Root/values/ReferenciaCodeudor/Contact/TelefonoCelular"/>
            </CelRefCod>
            <NomEmpLabCod>
                <xsl:value-of select="Root/values/CodeudorEmpleado/Empresa"/>
            </NomEmpLabCod>
            <AntVinEmpCod>
                <xsl:value-of select="Root/values/CodeudorEmpleado/Antiguedad"/>
            </AntVinEmpCod>
            <CarEmpLabCod>
                <xsl:value-of select="Root/values/CodeudorEmpleado/CargoProfesion"/>
            </CarEmpLabCod>
            <SalEmpLabCod>
                <xsl:value-of select="Root/values/CodeudorEmpleado/Salario"/>
            </SalEmpLabCod>
            <NomConEmpLabCod>
                <xsl:value-of select="Root/values/CodeudorEmpleado/ContactoLaboral"/>
            </NomConEmpLabCod>
            <CarConEmpLabCod>
                <xsl:value-of select="Root/values/CodeudorEmpleado/CargoContactoLaboral"/>
            </CarConEmpLabCod>
            <TelConEmpLabCod>
                <xsl:value-of select="Root/values/CodeudorEmpleado/TelefonoLaboral"/>
            </TelConEmpLabCod>
            <ObcConLab>
                <xsl:value-of select="Root/values/CodeudorEmpleado/ObservacionesLaboral"/>
            </ObcConLab>
            <DirEmpCod>
                <xsl:value-of select="Root/values/CodeudorEmpleado/Location/Direccion"/>
            </DirEmpCod>
            <IdeDepEmpCod>
                <xsl:value-of select="Root/values/CodeudorEmpleado/Location//DepartamentoMunicipioBarrio[0]"/>
            </IdeDepEmpCod>
            <IdeMunEmpCod>
                <xsl:value-of select="Root/values/CodeudorEmpleado/Location//DepartamentoMunicipioBarrio[1]"/>
            </IdeMunEmpCod>
            <IdeBarEmpCod>
                <xsl:value-of select="Root/values/CodeudorEmpleado/Location//DepartamentoMunicipioBarrio[2]"/>
            </IdeBarEmpCod>
            <NomNegCod>
                <xsl:value-of select="Root/values/DatosNegocioCodeudor/NombreRazonSocial"/>
            </NomNegCod>
            <FecCreNegCod>
                <xsl:value-of select="Root/values/DatosNegocioCodeudor/FechaInicio"/>
            </FecCreNegCod>
            <IdeSecNegCod>
                <xsl:value-of select="Root/values/DatosNegocioCodeudor/ActividadSector"/>
            </IdeSecNegCod>
            <IdeActEcoCod>
                <xsl:value-of select="Root/values/DatosNegocioCodeudor/ActividadSector"/>
            </IdeActEcoCod>
            <TipLocNegCod>
                <xsl:value-of select="Root/values/DatosNegocioCodeudor/TipoLocal[0]"/>
            </TipLocNegCod>
            <DirNegCod>
                <xsl:value-of select="Root/values/DatosNegocioCodeudor/Location/Direccion"/>
            </DirNegCod>
            <IndDirNegCod>
                <xsl:value-of select="Root/values/DatosNegocioCodeudor/Location/Ubicacion"/>
            </IndDirNegCod>
            <IdeBarDomCod>
                <xsl:value-of select="Root/values/DatosNegocioCodeudor/Location/DepartamentoMunicipioBarrio[2]"/>
            </IdeBarDomCod>
            <IdeMunDomCod>
                <xsl:value-of select="Root/values/DatosNegocioCodeudor/Location/DepartamentoMunicipioBarrio[1]"/>
            </IdeMunDomCod>
            <IdeDepDomCod>
                <xsl:value-of select="Root/values/DatosNegocioCodeudor/Location/DepartamentoMunicipioBarrio[0]"/>
            </IdeDepDomCod>
            <TelNegCod>
                <xsl:value-of select="Root/values/DatosNegocioCodeudor/Contact/TelefonoLocal"/>
            </TelNegCod>
            <CelNegCod>
                <xsl:value-of select="Root/values/DatosNegocioCodeudor/Contact/TelefonoCelular"/>
            </CelNegCod>
            <CanCod1>
                <xsl:value-of select="Root/values/GarantiasCodeudor/Cantidad"/>
            </CanCod1>
            <DesBieCod1>
                <xsl:value-of select="Root/values/GarantiasCodeudor/Descripcion"/>
            </DesBieCod1>
            <ValBieCod1>
                <xsl:value-of select="Root/values/GarantiasCodeudor/Valor"/>
            </ValBieCod1>
            <TipGar>
                <xsl:value-of select="Root/values/GarantiasCodeudor/TipoGarantia[0]"/>
            </TipGar>
            <CanCod2>
                <xsl:value-of select="Root/values/GarantiasCodeudor2/Cantidad"/>
            </CanCod2>
            <DesBieCod2>
                <xsl:value-of select="Root/values/GarantiasCodeudor2/Descripcion"/>
            </DesBieCod2>
            <ValBieCod2>
                <xsl:value-of select="Root/values/GarantiasCodeudor2/Valor"/>
            </ValBieCod2>
            <CanCod3>
                <xsl:value-of select="Root/values/GarantiasCodeudor3/Cantidad"/>
            </CanCod3>
            <DesBieCod3>
                <xsl:value-of select="Root/values/GarantiasCodeudor3/Descripcion"/>
            </DesBieCod3>
            <ValBieCod3>
                <xsl:value-of select="Root/values/GarantiasCodeudor3/Valor"/>
            </ValBieCod3>
            <CanCod4>
                <xsl:value-of select="Root/values/GarantiasCodeudor4/Cantidad"/>
            </CanCod4>
            <DesBieCod4>
                <xsl:value-of select="Root/values/GarantiasCodeudor4/Descripcion"/>
            </DesBieCod4>
            <ValBieCod4>
                <xsl:value-of select="Root/values/GarantiasCodeudor4/Valor"/>
            </ValBieCod4>
            <CanCod5>
                <xsl:value-of select="Root/values/GarantiasCodeudor5/Cantidad"/>
            </CanCod5>
            <DesBieCod5>
                <xsl:value-of select="Root/values/GarantiasCodeudor5/Descripcion"/>
            </DesBieCod5>
            <ValBieCod5>
                <xsl:value-of select="Root/values/GarantiasCodeudor5/Valor"/>
            </ValBieCod5>
            <CanCod6>
                <xsl:value-of select="Root/values/GarantiasCodeudor6/Cantidad"/>
            </CanCod6>
            <DesBieCod6>
                <xsl:value-of select="Root/values/GarantiasCodeudor6/Descripcion"/>
            </DesBieCod6>
            <ValBieCod6>
                <xsl:value-of select="Root/values/GarantiasCodeudor6/Valor"/>
            </ValBieCod6>
            <CanCod7>
                <xsl:value-of select="Root/values/GarantiasCodeudor7/Cantidad"/>
            </CanCod7>
            <DesBieCod7>
                <xsl:value-of select="Root/values/GarantiasCodeudor7/Descripcion"/>
            </DesBieCod7>
            <ValBieCod7>
                <xsl:value-of select="Root/values/GarantiasCodeudor7/Valor"/>
            </ValBieCod7>
            <CanCod8>
                <xsl:value-of select="Root/values/GarantiasCodeudor8/Cantidad"/>
            </CanCod8>
            <DesBieCod8>
                <xsl:value-of select="Root/values/GarantiasCodeudor8/Descripcion"/>
            </DesBieCod8>
            <ValBieCod8>
                <xsl:value-of select="Root/values/GarantiasCodeudor8/Valor"/>
            </ValBieCod8>
            <CanCod9>
                <xsl:value-of select="Root/values/GarantiasCodeudor9/Cantidad"/>
            </CanCod9>
            <DesBieCod9>
                <xsl:value-of select="Root/values/GarantiasCodeudor9/Descripcion"/>
            </DesBieCod9>
            <ValBieCod9>
                <xsl:value-of select="Root/values/GarantiasCodeudor9/Valor"/>
            </ValBieCod9>
            <CanCod10>
                <xsl:value-of select="Root/values/GarantiasCodeudor10/Cantidad"/>
            </CanCod10>
            <DesBieCod10>
                <xsl:value-of select="Root/values/GarantiasCodeudor10/Descripcion"/>
            </DesBieCod10>
            <ValBieCod10>
                <xsl:value-of select="Root/values/GarantiasCodeudor10/Valor"/>
            </ValBieCod10>
            <NumDocIdeBen>
                <xsl:value-of select="Root/values/Subject/Person/Id/NumeroDocCiudadania"/>
            </NumDocIdeBen>
            <NumDocIdeBenAuxInm>
                <xsl:value-of select="Root/values/Subject/Person/Id/NumeroDocCiudadania"/>
            </NumDocIdeBenAuxInm>
            <TipDocIdeBen>
                <xsl:value-of select="Root/values/Subject/Person/Id/TipoDocumento[0]"/>
            </TipDocIdeBen>
            <TipDocIdeBenAuxInm>
                <xsl:value-of select="Root/values/Subject/Person/Id/TipoDocumento[0]"/>
            </TipDocIdeBenAuxInm>
        </root>
    </xsl:template>
</xsl:stylesheet>