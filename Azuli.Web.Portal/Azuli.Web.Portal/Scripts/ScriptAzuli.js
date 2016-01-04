function ValidaTecla(campo, event, tipo) {
    //funcao de validação de campo em javascript para todos os navegadores do mercado
    //para esta função use da seguinte forma
    //<input type="text" name="teste" onkeypress="return validaTecla(this, event,'SOMENTE_VALORES');"> 
    //definindo se o formulario deve ser enviado ou não
    var strValidos;
    var caractere;
    var BACKSPACE = 8;
    var ENTER = 13;
    var key;
    var tecla;
    var max;
    var sMask;
    //variaveis da mascara
    var i, nCount, sValue, fldLen, mskLen, bolMask, sCod, nTecla;

    max = (campo.value.length + 1);

    //definindo símbolos permitidos
    switch (tipo) {
        case "SOMENTE_HORAS":
            {
                max = 8
                strValidos = "0123456789:"
                sMask = "99:99:99"
                break
            }
        case "SOMENTE_NUMEROS_PONTO":
            {
                strValidos = "0123456789."
                sMask = ""
                break
            }
        case "SOMENTE_NUMEROS":
            {
                strValidos = "0123456789"
                sMask = ""
                break
            }
        case "SOMENTE_VALORES":
            {
                strValidos = "0123456789,"
                sMask = ""
                break
            }
        case "SOMENTE_DATAS":
            {
                max = 10
                strValidos = "0123456789/"
                sMask = "99/99/9999"
                break
            }
        case "SOMENTE_FONE":
            {
                max = 13
                strValidos = "0123456789-"
                sMask = "(99)9999-9999"
                break
            }
        case "SOMENTE_CEP":
            {
                max = 9
                strValidos = "0123456789-"
                sMask = "99999-999"
                break
            }
        case "SOMENTE_CNPJ":
            {
                max = 18
                strValidos = "0123456789/-."
                sMask = "99.999.999/9999-99"
                break
            }
        case "SOMENTE_CPF":
            {
                max = 18
                strValidos = "0123456789/-."
                sMask = "999.999.999-99"
                break
            }
        case "ACEITA_TUDO":
            {
                strValidos = ""
                sMask = ""
                break
            }
    }

    //inicio mascara
    if (window.event) {
        // Internet Explorer       
        nTecla = event.keyCode;
    }
    else if (event.which) {
        // Nestcape / firefox       
        nTecla = event.which;
    }
    //se for backspace não faz nada    
    if (nTecla != 8) {
        sValue = new String(campo.value);
        // alert(sValue);     
        // Limpa todos os caracteres de formatação que     
        // já estiverem no campo.     
        sValue = ReplaceAll(sValue, ":", "");
        sValue = ReplaceAll(sValue, "-", "");
        sValue = ReplaceAll(sValue, ".", "");
        sValue = ReplaceAll(sValue, ".", "");
        sValue = ReplaceAll(sValue, "/", "");
        sValue = ReplaceAll(sValue, "(", "");
        sValue = ReplaceAll(sValue, ")", "");
        sValue = ReplaceAll(sValue, " ", "");

        fldLen = sValue.length;
        mskLen = sMask.length;
        i = 0;
        nCount = 0;
        sCod = "";
        mskLen = fldLen;
        while (i <= mskLen) {
            bolMask = ((sMask.charAt(i) == "-") || (sMask.charAt(i) == ".") || (sMask.charAt(i) == "/") || (sMask.charAt(i) == ":"))
            bolMask = bolMask || ((sMask.charAt(i) == "(") || (sMask.charAt(i) == ")") || (sMask.charAt(i) == " "))
            if (bolMask) {
                sCod += sMask.charAt(i);
                mskLen++;
            }
            else {
                sCod += sValue.charAt(nCount);
                nCount++;
            }
            i++;
        }
        campo.value = sCod;
        //limita o tamanho
        campo.value = campo.value.substr(0, max - 1);

        if (nTecla != 8) {
            // backspace       
            if (sMask.charAt(i - 1) == "9") {
                // apenas números...         
                return ((nTecla > 47) && (nTecla < 58));
            }
            else // números de 0 a 9        
            {
                // qualquer caracter...         
                return true;
            }
        }
        else {
            return true;
        }
    }
}

function Mascara(objeto) {
    if (objeto.value.length == 0)
        objeto.value = '(' + objeto.value;

    if (objeto.value.length == 3)
        objeto.value = objeto.value + ')';

    if (objeto.value.length == 8)
        objeto.value = objeto.value + '-';
}

function Decimal(obj, e) {
    var tecla = (window.event) ? e.keyCode : e.which;
    if (tecla == 8 || tecla == 0)
        return true;
    if (tecla != 44 && tecla < 48 || tecla > 57)
        return false;
}


function (d, s, id) 
{
 var js, fjs = d.getElementsByTagName(s)[0];
 if (d.getElementById(id)) return;
 js = d.createElement(s); js.id = id;
 js.src = "//connect.facebook.net/pt_BR/all.js#xfbml=1";
 fjs.parentNode.insertBefore(js, fjs);
 } (document, 'script', 'facebook-jssdk');



