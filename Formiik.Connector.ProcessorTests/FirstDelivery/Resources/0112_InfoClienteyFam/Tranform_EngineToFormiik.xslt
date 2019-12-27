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
            <Municipio />
            <Ciudad/>
            <latitude><xsl:value-of select="Root/values/PosicionNegocio/Latitude"/></latitude>
            <longitude><xsl:value-of select="Root/values/PosicionNegocio/Longitude"/></longitude>
            <TipDocCliInfo><xsl:value-of select="Root/values/Titular/TipoDocumento"/></TipDocCliInfo>
            <PaiExpCliInfo><xsl:value-of select="Root/values/Titular/PaisExpedicion"/></PaiExpCliInfo>
            <IdReaderCedula_CedulaInfo><xsl:value-of select="Root/values/Titular/NumeroDocumento"/></IdReaderCedula_CedulaInfo>
            <IdReaderPrimerNombre_PrimerNombre><xsl:value-of select="Root/values/Titular/PrimerNombre"/></IdReaderPrimerNombre_PrimerNombre>
            <IdReaderSegundoNombre_SegundoNombre><xsl:value-of select="Root/values/Titular/SegundoNombre"/></IdReaderSegundoNombre_SegundoNombre>
            <IdReaderPrimerApellido_ApellidoPat><xsl:value-of select="Root/values/Titular/PrimerApellido"/></IdReaderPrimerApellido_ApellidoPat>
            <IdReaderSegundoApellido_ApellidoMat><xsl:value-of select="Root/values/Titular/SegundoApellido"/></IdReaderSegundoApellido_ApellidoMat>
            <FechNac><xsl:value-of select="Root/values/Titular/FechaNacimiento"/></FechNac>
            <IdReaderSexo_Sexo><xsl:value-of select="Root/values/Titular/Genero"/></IdReaderSexo_Sexo>
            <EstadoCivil><xsl:value-of select="Root/values/Titular/EstadoCivil"/></EstadoCivil>
            <DatosPLCon>
                <FormEditResponse>
                    <DatosConyuge>
                        <DatosPeryLabCon>
                            <xsl:for-each select="Root/values/Conyuge">
                                <TipDocCon><xsl:value-of select="DatosConyuge/TipoDocumento"/></TipDocCon>
                                <IdReaderSegundoNombre_SegundoNombreCon><xsl:value-of select="DatosConyuge/SegundoNombre"/></IdReaderSegundoNombre_SegundoNombreCon>
                                <IdReaderSegundoApellido_ApellidoMatCon><xsl:value-of select="DatosConyuge/SegundoApellido"/></IdReaderSegundoApellido_ApellidoMatCon>
                                <IdReaderPrimerNombre_PrimerNombreCon><xsl:value-of select="DatosConyuge/PrimerNombre"/></IdReaderPrimerNombre_PrimerNombreCon>
                                <IdReaderPrimerApellido_ApellidoPatCon><xsl:value-of select="DatosConyuge/PrimerApellido"/></IdReaderPrimerApellido_ApellidoPatCon>
                                <PaiExpCon><xsl:value-of select="DatosConyuge/PaisExpedicion"/></PaiExpCon>
                                <IdReaderCedula_CedulaCon><xsl:value-of select="DatosConyuge/NumeroDocumento"/></IdReaderCedula_CedulaCon>
                                <NivEducCon><xsl:value-of select="DatosConyuge/NivelEducativo"/></NivEducCon>
                                <FechNacCon><xsl:value-of select="DatosConyuge/FechaNacimiento"/></FechNacCon>
                                <ActiCon><xsl:value-of select="ActividadConyuge"/></ActiCon>
                            </xsl:for-each>
                            <xsl:for-each select="Root/values/ContactoConyuge">
                                <TelDomCon><xsl:value-of select="Telefono"/></TelDomCon>
                                <CelPerCon><xsl:value-of select="TelefonoCelular"/></CelPerCon>
                                <CorEleCon><xsl:value-of select="CorreoElectronico"/></CorEleCon>
                            </xsl:for-each>
                        </DatosPeryLabCon>
                    </DatosConyuge>
                </FormEditResponse>
            </DatosPLCon>
            <TipoDomCli>
                <xsl:value-of select="Root/values/TipoDomicilio"/>
            </TipoDomCli>
            <DatDom>
                <FormEditResponse>
                    <DatosDomicilio>
                        <DatosDomicilio>
                            <TelDueno><xsl:value-of select="Root/values/TelefonoDuenioHogarFamiliar"/></TelDueno>
                            <RentaMns><xsl:value-of select="Root/values/RentaMensualArrendado"/></RentaMns>
                            <NombDueno><xsl:value-of select="Root/values/NombreDuenioHogarFamiliar"/></NombDueno>
                            <CorEleArrend><xsl:value-of select="Root/values/CorreoElectronicoArrendador"/></CorEleArrend>
                            <CorEleDueno><xsl:value-of select="Root/values/CorreoElectronicoDuenioHogarFamiliar"/></CorEleDueno>
                            <CostAnPred><xsl:value-of select="Root/values/CostoAnualPredial"/></CostAnPred>
                            <xsl:if test = "Root/values/CuentaConAccesoAInternet = 'true'">
                            <CuentaAccInter><xsl:text>Si</xsl:text></CuentaAccInter>
                            </xsl:if>
                            <xsl:if test = "Root/values/CuentaConAccesoAInternet = 'false'">
                                <CuentaAccInter><xsl:text>No</xsl:text></CuentaAccInter>
                            </xsl:if>
                            <xsl:if test = "Root/values/CuentaConAguaPotable = 'true'">
                                <CuentaAguaPot><xsl:text>Si</xsl:text></CuentaAguaPot>
                            </xsl:if>
                            <xsl:if test = "Root/values/CuentaConAguaPotable = 'false'">
                                <CuentaAguaPot><xsl:text>No</xsl:text></CuentaAguaPot>
                            </xsl:if>
                            <TiempoResid><xsl:value-of select="Root/values/TiempoResidencia"/></TiempoResid>
                            <AntigProp><xsl:value-of select="Root/values/AntiguedadPropiedad"/></AntigProp>
                            <ValorProp><xsl:value-of select="Root/values/ValorPropiedadFinanciado"/></ValorProp>
                            <PagoMens><xsl:value-of select="Root/values/PagoMensualFinanciado"/></PagoMens>
                            <NombArrend><xsl:value-of select="Root/values/NombreArrendador"/></NombArrend>
                            <TelArrend><xsl:value-of select="Root/values/TelefonoArrendador"/></TelArrend>
                        </DatosDomicilio>
                    </DatosDomicilio>
                </FormEditResponse>
            </DatDom>
            <xsl:if test="string-length(Root/values/ImagenComprobanteDomicilio/FileUrl) > 0">
                <FotoComprobanteDom>
                    &lt;!DOCTYPE html&gt; &lt;html&gt; &lt;head&gt; &lt;/head&gt; &lt;body&gt; &lt;table id=&quot;t01&quot;&gt; &lt;tr&gt; &lt;td&gt; &lt;img src= &quot;<xsl:value-of select="Root/values/ImagenComprobanteDomicilio/FileUrl"/>&quot; width=&quot;1000&quot; height=&quot;1000&quot;&gt; &lt;/td&gt; &lt;/tr&gt; &lt;/table&gt; &lt;/body&gt; &lt;/html&gt;
                </FotoComprobanteDom>
            </xsl:if>
            <xsl:if test="string-length(Root/values/ImagenCedulaAnverso/FileUrl) > 0">
                <FotoCedulaAnverso>
                    &lt;!DOCTYPE html&gt; &lt;html&gt; &lt;head&gt; &lt;/head&gt; &lt;body&gt; &lt;table id=&quot;t01&quot;&gt; &lt;tr&gt; &lt;td&gt; &lt;img src= &quot;<xsl:value-of select="Root/values/ImagenCedulaAnverso/FileUrl"/>&quot; width=&quot;1000&quot; height=&quot;1000&quot;&gt; &lt;/td&gt; &lt;/tr&gt; &lt;/table&gt; &lt;/body&gt; &lt;/html&gt;
                </FotoCedulaAnverso>
            </xsl:if>
            <xsl:if test="string-length(Root/values/ImagenCedulaReverso/FileUrl) > 0">
                <FotoCedulaReverso>
                    &lt;!DOCTYPE html&gt; &lt;html&gt; &lt;head&gt; &lt;/head&gt; &lt;body&gt; &lt;table id=&quot;t01&quot;&gt; &lt;tr&gt; &lt;td&gt; &lt;img src= &quot;<xsl:value-of select="Root/values/ImagenCedulaReverso/FileUrl"/>&quot; width=&quot;1000&quot; height=&quot;1000&quot;&gt; &lt;/td&gt; &lt;/tr&gt; &lt;/table&gt; &lt;/body&gt; &lt;/html&gt;
                </FotoCedulaReverso>
            </xsl:if>
            <NomDepBarDomCli><xsl:value-of select="Root/values/ContactoTitular/Direccion/*[2]"/></NomDepBarDomCli>
            <NomMunBarDomCli><xsl:value-of select="Root/values/ContactoTitular/Direccion/*[3]"/></NomMunBarDomCli>
            <NomBarDomCli><xsl:value-of select="Root/values/ContactoTitular/Direccion/*[4]"/></NomBarDomCli>
            <CalleNum><xsl:value-of select="Root/values/ContactoTitular/Direccion/CalleYNumero"/></CalleNum>
            <TelDomCli><xsl:value-of select="Root/values/ContactoTitular/Telefono"/></TelDomCli>
            <CelPerCli><xsl:value-of select="Root/values/ContactoTitular/TelefonoCelular"/></CelPerCli>
            <CorEleCli><xsl:value-of select="Root/values/ContactoTitular/CorreoElectronico"/></CorEleCli>
            <NivEduc><xsl:value-of select="Root/values/Titular/NivelEducativo"/></NivEduc>
            <xsl:if test = "Root/values/TitularEsEmpleado = 'true'">
                <CliEmpl><xsl:text>Si</xsl:text></CliEmpl>
            </xsl:if>
            <xsl:if test = "Root/values/TitularEsEmpleado = 'false'">
                <CliEmpl><xsl:text>No</xsl:text></CliEmpl>
            </xsl:if>
            <DatEmp>
                <FormEditResponse>
                    <DatosLaborales>
                        <DatosLaborales>
                            <DirEmpCli><xsl:value-of select="Root/values/DireccionEmpresaEmpleoTitular"/></DirEmpCli>
                            <EmpresaCli><xsl:value-of select="Root/values/EmpresaDondeLaboraTitular"/></EmpresaCli>
                            <AntigEmpCli><xsl:value-of select="Root/values/AntiguedadEmpleoTitular"/></AntigEmpCli>
                            <SalEmpCli><xsl:value-of select="Root/values/SalarioEmpleoTitular"/></SalEmpCli>
                            <NomContEmp><xsl:value-of select="Root/values/NombreContactoEmpleoTitular"/></NomContEmp>
                            <TelEmpCli><xsl:value-of select="Root/values/TelefonoEmpresaEmpleoTitular"/></TelEmpCli>
                        </DatosLaborales>
                    </DatosLaborales>
                </FormEditResponse>
            </DatEmp>
            <DatosNuc>
                <FormEditResponse>
                    <DatosNucleo>
                        <DatNucleo>
                            <NumMiemFam><xsl:value-of select="Root/values/NumeroMiembrosFamilia"/></NumMiemFam>
                            <TotPersCargo><xsl:value-of select="Root/values/TotalPersonasACargo"/></TotPersCargo>
                            <NumHijos><xsl:value-of select="Root/values/NumeroHijos"/></NumHijos>
                            <xsl:if test = "Root/values/TitularCabezaHogar = 'true'">
                                <TitularCabHogar><xsl:text>Si</xsl:text></TitularCabHogar>
                            </xsl:if>
                            <xsl:if test = "Root/values/TitularCabezaHogar = 'false'">
                                <TitularCabHogar><xsl:text>No</xsl:text></TitularCabHogar>
                            </xsl:if>
                            <xsl:if test = "Root/values/TitularSabeLeerEscribir = 'true'">
                                <TitLeerEsc><xsl:text>Si</xsl:text></TitLeerEsc>
                            </xsl:if>
                            <xsl:if test = "Root/values/TitularSabeLeerEscribir = 'false'">
                                <TitLeerEsc><xsl:text>No</xsl:text></TitLeerEsc>
                            </xsl:if>
                        </DatNucleo>
                    </DatosNucleo>
                </FormEditResponse>
            </DatosNuc>
            <AddressText><xsl:value-of select="Root/values/DireccionNegocio"/></AddressText>
        </root>
    </xsl:template>
</xsl:stylesheet>