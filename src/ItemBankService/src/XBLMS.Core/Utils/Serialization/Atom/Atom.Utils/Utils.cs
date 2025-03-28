/* 
  	* Utils.cs
	* [ part of Atom.NET library: http://atomnet.sourceforge.net ]
	* Author: Lawrence Oluyede
	* License: BSD-License (see below)
    
	Copyright (c) 2003, 2004 Lawrence Oluyede
    All rights reserved.

    Redistribution and use in source and binary forms, with or without
    modification, are permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright notice,
    * this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
    * notice, this list of conditions and the following disclaimer in the
    * documentation and/or other materials provided with the distribution.
    * Neither the name of the copyright owner nor the names of its
    * contributors may be used to endorse or promote products derived from
    * this software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
    AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
    IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
    ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
    LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
    CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
    SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
    INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
    CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
    ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
    POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using XBLMS.Core.Utils.Serialization.Atom.Atom.Core;

namespace XBLMS.Core.Utils.Serialization.Atom.Atom.Utils
{
    /// <summary>
    /// A class with some useful methods.
    /// </summary>
    public sealed class Utils
	{
		private static Hashtable _mediaTypes = null;

		#region Constructors
		private Utils() {}

		/// <summary>
		/// Read in the hash table the contents of the embedded text file
		/// containing the media types
		/// </summary>
		static Utils()
		{
            _mediaTypes = new Hashtable();

			using(StringReader reader = new StringReader(@"application/activemessage http://www.iana.org/assignments/media-types/application/activemessage
application/andrew-inset http://www.iana.org/assignments/media-types/application/andrew-inset
application/applefile http://www.iana.org/assignments/media-types/application/applefile
application/atomicmail http://www.iana.org/assignments/media-types/application/atomicmail
application/atom+xml http://www.mnot.net/drafts/draft-nottingham-atom-format-02.html#rfc.section.8
application/batch-SMTP http://www.rfc-editor.org/rfc/rfc2442.txt
application/beep+xml http://www.rfc-editor.org/rfc/rfc3080.txt
application/cals-1840 http://www.rfc-editor.org/rfc/rfc1895.txt
application/commonground http://www.iana.org/assignments/media-types/application/commonground
application/cybercash http://www.iana.org/assignments/media-types/application/cybercash
application/dca-rft http://www.iana.org/assignments/media-types/application/dca-rft
application/dec-dx http://www.iana.org/assignments/media-types/application/dec-dx
application/dicom http://www.rfc-editor.org/rfc/rfc3240.txt
application/dvcs http://www.rfc-editor.org/rfc/rfc3029.txt
application/EDI-Consent http://www.rfc-editor.org/rfc/rfc1767.txt
application/EDIFACT http://www.rfc-editor.org/rfc/rfc1767.txt
application/EDI-X12 http://www.rfc-editor.org/rfc/rfc1767.txt
application/eshop http://www.iana.org/assignments/media-types/application/eshop
application/font-tdpfr http://www.rfc-editor.org/rfc/rfc3073.txt
application/http http://www.rfc-editor.org/rfc/rfc2616.txt
application/hyperstudio http://www.iana.org/assignments/media-types/application/hyperstudio
application/iges http://www.iana.org/assignments/media-types/application/iges
application/index http://www.rfc-editor.org/rfc/rfc2652.txt
application/index.cmd http://www.rfc-editor.org/rfc/rfc2652.txt
application/index.obj http://www.rfc-editor.org/rfc/rfc2652.txt
application/index.response http://www.rfc-editor.org/rfc/rfc2652.txt
application/index.vnd http://www.rfc-editor.org/rfc/rfc2652.txt
application/iotp http://www.rfc-editor.org/rfc/rfc2935.txt
application/ipp http://www.rfc-editor.org/rfc/rfc2910.txt
application/isup http://www.rfc-editor.org/rfc/rfc3204.txt
application/mac-binhex40 http://www.iana.org/assignments/media-types/application/mac-binhex40
application/macwriteii http://www.iana.org/assignments/media-types/application/macwriteii
application/marc http://www.rfc-editor.org/rfc/rfc2220.txt
application/mathematica http://www.iana.org/assignments/media-types/application/mathematica
application/mpeg4-generic http://www.rfc-editor.org/rfc/rfc3640.txt
application/msword http://www.iana.org/assignments/media-types/application/msword
application/news-message-id http://www.rfc-editor.org/rfc/rfc1036.txt
application/news-transmission http://www.rfc-editor.org/rfc/rfc1036.txt
application/ocsp-request http://www.rfc-editor.org/rfc/rfc2560.txt
application/ocsp-response http://www.rfc-editor.org/rfc/rfc2560.txt
application/octet-stream http://www.ietf.org/rfc/rfc2046.txt
application/oda http://www.ietf.org/rfc/rfc2046.txt
application/ogg http://www.rfc-editor.org/rfc/rfc3534.txt
application/parityfec http://www.rfc-editor.org/rfc/rfc3009.txt
application/pdf http://www.iana.org/assignments/media-types/application/pdf
application/pgp-encrypted http://www.rfc-editor.org/rfc/rfc3156.txt
application/pgp-keys http://www.rfc-editor.org/rfc/rfc3156.txt
application/pgp-signature http://www.rfc-editor.org/rfc/rfc3156.txt
application/pkcs10 http://www.rfc-editor.org/rfc/rfc2311.txt
application/pkcs7-mime http://www.rfc-editor.org/rfc/rfc2311.txt
application/pkcs7-signature http://www.rfc-editor.org/rfc/rfc2311.txt
application/pkix-cert http://www.rfc-editor.org/rfc/rfc2585.txt
application/pkixcmp http://www.rfc-editor.org/rfc/rfc2510.txt
application/pkix-crl http://www.rfc-editor.org/rfc/rfc2585.txt
application/pkix-pkipath http://www.rfc-editor.org/rfc/rfc3546.txt
application/postscript http://www.rfc-editor.org/rfc/rfc2046.txt
application/prs.alvestrand.titrax-sheet http://www.iana.org/assignments/media-types/application/prs.alvestrand.titrax-sheet
application/prs.cww http://www.iana.org/assignments/media-types/application/prs.cww
application/prs.nprend http://www.iana.org/assignments/media-types/application/prs.nprend
application/prs.plucker http://www.iana.org/assignments/media-types/application/prs.plucker
application/qsig http://www.ietf.org/rfc/rfc3204.txt
application/remote-printing http://www.rfc-editor.org/rfc/rfc1486.txt
application/riscos http://www.iana.org/assignments/media-types/application/riscos
application/rtf http://www.iana.org/assignments/media-types/application/rtf
application/sdp http://www.rfc-editor.org/rfc/rfc2327.txt
application/set-payment http://www.iana.org/assignments/media-types/application/set-payment
application/set-payment-initiation http://www.iana.org/assignments/media-types/application/set-payment-initiation
application/set-registration http://www.iana.org/assignments/media-types/application/set-registration
application/set-registration-initiation http://www.iana.org/assignments/media-types/application/set-registration-initiation
application/sgml http://www.rfc-editor.org/rfc/rfc1874.txt
application/sgml-open-catalog http://www.iana.org/assignments/media-types/application/sgml-open-catalog
application/sieve http://www.rfc-editor.org/rfc/rfc3028.txt
application/slate http://www.iana.org/assignments/media-types/application/slate
application/timestamp-query http://www.rfc-editor.org/rfc/rfc3161.txt
application/timestamp-reply http://www.rfc-editor.org/rfc/rfc3161.txt
application/tve-trigger http://www.iana.org/assignments/media-types/application/tve-trigger
application/vemmi http://www.rfc-editor.org/rfc/rfc2122.txt
application/vnd.3gpp.pic-bw-large http://www.iana.org/assignments/media-types/application/vnd.3gpp.pic-bw-large
application/vnd.3gpp.pic-bw-small http://www.iana.org/assignments/media-types/application/vnd.3gpp.pic-bw-small
application/vnd.3gpp.pic-bw-var http://www.iana.org/assignments/media-types/application/vnd.3gpp.pic-bw-var
application/vnd.3gpp.sms http://www.iana.org/assignments/media-types/application/vnd.3gpp.sms
application/vnd.3M.Post-it-Notes http://www.iana.org/assignments/media-types/application/vnd.3M.Post-it-Notes
application/vnd.accpac.simply.aso http://www.iana.org/assignments/media-types/application/vnd.accpac.simply.aso
application/vnd.accpac.simply.imp http://www.iana.org/assignments/media-types/application/vnd.accpac.simply.imp
application/vnd.acucobol http://www.iana.org/assignments/media-types/application/vnd-acucobol
application/vnd.acucorp http://www.iana.org/assignments/media-types/application/vnd.acucorp
application/vnd.adobe.xfdf http://www.iana.org/assignments/media-types/application/vnd.adobe.xfdf
application/vnd.aether.imp http://www.iana.org/assignments/media-types/application/vnd.aether.imp
application/vnd.amiga.ami http://www.iana.org/assignments/media-types/application/vnd.amiga.ami
application/vnd.anser-web-certificate-issue-initiation http://www.iana.org/assignments/media-types/application/vnd.anser-web-certificate-issue-initiation
application/vnd.anser-web-funds-transfer-initiation http://www.iana.org/assignments/media-types/application/vnd.anser-web-funds-transfer-initiation
application/vnd.audiograph http://www.iana.org/assignments/media-types/application/vnd.audiograph
application/vnd.blueice.multipass http://www.iana.org/assignments/media-types/application/vnd.blueice.multipass
application/vnd.bmi http://www.iana.org/assignments/media-types/application/vnd.bmi
application/vnd.businessobjects http://www.iana.org/assignments/media-types/application/vnd.businessobjects
application/vnd.canon-cpdl http://www.iana.org/assignments/media-types/application/vnd.canon-cpdl
application/vnd.canon-lips http://www.iana.org/assignments/media-types/application/vnd.canon-lips
application/vnd.cinderella http://www.iana.org/assignments/media-types/application/vnd.cinderella
application/vnd.claymore http://www.iana.org/assignments/media-types/application/vnd.claymore
application/vnd.commerce-battelle http://www.iana.org/assignments/media-types/application/vnd.commerce-battelle
application/vnd.commonspace http://www.iana.org/assignments/media-types/application/vnd.commonspace
application/vnd.cosmocaller http://www.iana.org/assignments/media-types/application/vnd.cosmocaller
application/vnd.contact.cmsg http://www.iana.org/assignments/media-types/application/vnd.contact.cmsg
application/vnd.criticaltools.wbs+xml http://www.iana.org/assignments/media-types/application/vnd.criticaltools.wbs+xml
application/vnd.ctc-posml http://www.iana.org/assignments/media-types/application/vnd.ctc-posml
application/vnd.cups-postscript http://www.iana.org/assignments/media-types/application/vnd.cups-postscript
application/vnd.cups-raster http://www.iana.org/assignments/media-types/application/vnd.cups-raster
application/vnd.cups-raw http://www.iana.org/assignments/media-types/application/vnd.cups-raw
application/vnd.curl http://www.iana.org/assignments/media-types/application/vnd-curl
application/vnd.cybank http://www.iana.org/assignments/media-types/application/vnd.cybank
application/vnd.data-vision.rdz http://www.iana.org/assignments/media-types/application/vnd.data-vision.rdz
application/vnd.dna http://www.iana.org/assignments/media-types/application/vnd.dna
application/vnd.dpgraph http://www.iana.org/assignments/media-types/application/vnd.dpgraph
application/vnd.dreamfactory http://www.iana.org/assignments/media-types/application/vnd.dreamfactory
application/vnd.dxr http://www.iana.org/assignments/media-types/application/vnd-dxr
application/vnd.ecdis-update http://www.iana.org/assignments/media-types/application/vnd.ecdis-update
application/vnd.ecowin.chart http://www.iana.org/assignments/media-types/application/vnd.ecowin.chart
application/vnd.ecowin.filerequest http://www.iana.org/assignments/media-types/application/vnd.ecowin.filerequest
application/vnd.ecowin.fileupdate http://www.iana.org/assignments/media-types/application/vnd.ecowin.fileupdate
application/vnd.ecowin.series http://www.iana.org/assignments/media-types/application/vnd.ecowin.series
application/vnd.ecowin.seriesrequest http://www.iana.org/assignments/media-types/application/vnd.ecowin.seriesrequest
application/vnd.ecowin.seriesupdate http://www.iana.org/assignments/media-types/application/vnd.ecowin.seriesupdate
application/vnd.enliven http://www.iana.org/assignments/media-types/application/vnd.enliven
application/vnd.epson.esf http://www.iana.org/assignments/media-types/application/vnd.epson.esf
application/vnd.epson.msf http://www.iana.org/assignments/media-types/application/vnd.epson.msf
application/vnd.epson.quickanime http://www.iana.org/assignments/media-types/application/vnd.epson.quickanime
application/vnd.epson.salt http://www.iana.org/assignments/media-types/application/vnd.epson.salt
application/vnd.epson.ssf http://www.iana.org/assignments/media-types/application/vnd.epson.ssf
application/vnd.ericsson.quickcall http://www.iana.org/assignments/media-types/application/vnd.ericsson.quickcall
application/vnd.eudora.data http://www.iana.org/assignments/media-types/application/vnd.eudora.data
application/vnd.fdf http://www.iana.org/assignments/media-types/application/vnd-fdf
application/vnd.ffsns http://www.iana.org/assignments/media-types/application/vnd.ffsns
application/vnd.fints http://www.iana.org/assignments/media-types/application/vnd.fints
application/vnd.FloGraphIt http://www.iana.org/assignments/media-types/application/vnd.FloGraphIt
application/vnd.framemaker http://www.iana.org/assignments/media-types/application/vnd.framemaker
application/vnd.fsc.weblaunch http://www.iana.org/assignments/media-types/application/vnd.fsc.weblaunch
application/vnd.fujitsu.oasys http://www.iana.org/assignments/media-types/application/vnd.fujitsu.oasys
application/vnd.fujitsu.oasys2 http://www.iana.org/assignments/media-types/application/vnd.fujitsu.oasys2
application/vnd.fujitsu.oasys3 http://www.iana.org/assignments/media-types/application/vnd.fujitsu.oasys3
application/vnd.fujitsu.oasysgp http://www.iana.org/assignments/media-types/application/vnd.fujitsu.oasysgp
application/vnd.fujitsu.oasysprs http://www.iana.org/assignments/media-types/application/vnd.fujitsu.oasysprs
application/vnd.fujixerox.ddd http://www.iana.org/assignments/media-types/application/vnd.fujixerox.ddd
application/vnd.fujixerox.docuworks http://www.iana.org/assignments/media-types/application/vnd.fujixerox.docuworks
application/vnd.fujixerox.docuworks.binder http://www.iana.org/assignments/media-types/application/vnd.fujixerox.docuworks.binder
application/vnd.fut-misnet http://www.iana.org/assignments/media-types/application/vnd.fut-misnet
application/vnd.genomatix.tuxedo http://www.iana.org/assignments/media-types/application/vnd.genomatix.tuxedo
application/vnd.grafeq http://www.iana.org/assignments/media-types/application/vnd.grafeq
application/vnd.groove-account http://www.iana.org/assignments/media-types/application/vnd.groove-account
application/vnd.groove-help http://www.iana.org/assignments/media-types/application/vnd.groove-help
application/vnd.groove-identity-message http://www.iana.org/assignments/media-types/application/vnd.groove-identity-message
application/vnd.groove-injector http://www.iana.org/assignments/media-types/application/vnd.groove-injector
application/vnd.groove-tool-message http://www.iana.org/assignments/media-types/application/vnd.groove-tool-message
application/vnd.groove-tool-template http://www.iana.org/assignments/media-types/application/vnd.groove-tool-template
application/vnd.groove-vcard http://www.iana.org/assignments/media-types/application/vnd.groove-vcard
application/vnd.hbci http://www.iana.org/assignments/media-types/application/vnd.hbci
application/vnd.hhe.lesson-player http://www.iana.org/assignments/media-types/application/vnd.hhe.lesson-player
application/vnd.hp-HPGL http://www.iana.org/assignments/media-types/application/vnd.hp-HPGL
application/vnd.hp-hpid http://www.iana.org/assignments/media-types/application/vnd.hp-hpid
application/vnd.hp-hps http://www.iana.org/assignments/media-types/application/vnd.hp-hps
application/vnd.hp-PCL http://www.iana.org/assignments/media-types/application/vnd.hp-PCL
application/vnd.hp-PCLXL http://www.iana.org/assignments/media-types/application/vnd.hp-PCLXL
application/vnd.httphone http://www.iana.org/assignments/media-types/application/vnd.httphone
application/vnd.hzn-3d-crossword http://www.iana.org/assignments/media-types/application/vnd.hzn-3d-crossword
application/vnd.ibm.afplinedata http://www.iana.org/assignments/media-types/application/vnd.ibm.afplinedata
application/vnd.ibm.electronic-media http://www.iana.org/assignments/media-types/application/vnd.ibm.electronic-media
application/vnd.ibm.MiniPay http://www.iana.org/assignments/media-types/application/vnd.ibm.MiniPay
application/vnd.ibm.modcap http://www.iana.org/assignments/media-types/application/vnd.ibm.modcap
application/vnd.ibm.rights-management http://www.iana.org/assignments/media-types/application/vnd.ibm.rights-management
application/vnd.ibm.secure-container http://www.iana.org/assignments/media-types/application/vnd.ibm.secure-container
application/vnd.informix-visionary http://www.iana.org/assignments/media-types/application/vnd.informix-visionary
application/vnd.intercon.formnet http://www.iana.org/assignments/media-types/application/vnd.intercon.formnet
application/vnd.intertrust.digibox http://www.iana.org/assignments/media-types/application/vnd.intertrust.digibox
application/vnd.intertrust.nncp http://www.iana.org/assignments/media-types/application/vnd.intertrust.nncp
application/vnd.intu.qbo http://www.iana.org/assignments/media-types/application/vnd.intu.qbo
application/vnd.intu.qfx http://www.iana.org/assignments/media-types/application/vnd.intu.qfx
application/vnd.ipunplugged.rcprofile http://www.iana.org/assignments/media-types/application/vnd.ipunplugged.rcprofile
application/vnd.irepository.package+xml http://www.iana.org/assignments/media-types/application/vnd.irepository.package+xml
application/vnd.is-xpr http://www.iana.org/assignments/media-types/application/vnd.is-xpr
application/vnd.japannet-directory-service http://www.iana.org/assignments/media-types/application/vnd.japannet-directory-service
application/vnd.japannet-jpnstore-wakeup http://www.iana.org/assignments/media-types/application/vnd.japannet-jpnstore-wakeup
application/vnd.japannet-payment-wakeup http://www.iana.org/assignments/media-types/application/vnd.japannet-payment-wakeup
application/vnd.japannet-registration http://www.iana.org/assignments/media-types/application/vnd.japannet-registration
application/vnd.japannet-registration-wakeup http://www.iana.org/assignments/media-types/application/vnd.japannet-registration-wakeup
application/vnd.japannet-setstore-wakeup http://www.iana.org/assignments/media-types/application/vnd.japannet-setstore-wakeup
application/vnd.japannet-verification http://www.iana.org/assignments/media-types/application/vnd.japannet-verification
application/vnd.japannet-verification-wakeup http://www.iana.org/assignments/media-types/application/vnd.japannet-verification-wakeup
application/vnd.jisp http://www.iana.org/assignments/media-types/application/vnd.jisp
application/vnd.kde.karbon http://www.iana.org/assignments/media-types/application/vnd.kde.karbon
application/vnd.kde.kchart http://www.iana.org/assignments/media-types/application/vnd.kde.kchart
application/vnd.kde.kformula http://www.iana.org/assignments/media-types/application/vnd.kde.kformula
application/vnd.kde.kivio http://www.iana.org/assignments/media-types/application/vnd.kde.kivio
application/vnd.kde.kontour http://www.iana.org/assignments/media-types/application/vnd.kde.kontour
application/vnd.kde.kpresenter http://www.iana.org/assignments/media-types/application/vnd.kde.kpresenter
application/vnd.kde.kspread http://www.iana.org/assignments/media-types/application/vnd.kde.kspread
application/vnd.kde.kword http://www.iana.org/assignments/media-types/application/vnd.kde.kword
application/vnd.kenameaapp http://www.iana.org/assignments/media-types/application/vnd.kenameaapp
application/vnd.kidspiration http://www.iana.org/assignments/media-types/application/vnd.kidspiration
application/vnd.koan http://www.iana.org/assignments/media-types/application/vnd.koan
application/vnd.liberty-request+xml http://www.iana.org/assignments/media-types/application/vnd.liberty-request+xml
application/vnd.llamagraphics.life-balance.desktop http://www.iana.org/assignments/media-types/application/vnd.llamagraphics.life-balance.desktop
application/vnd.llamagraphics.life-balance.exchange+xml http://www.iana.org/assignments/media-types/application/vnd.llamagraphics.life-balance.exchange+xml
application/vnd.lotus-1-2-3 http://www.iana.org/assignments/media-types/application/vnd.lotus-1-2-3
application/vnd.lotus-approach http://www.iana.org/assignments/media-types/application/vnd.lotus-approach
application/vnd.lotus-freelance http://www.iana.org/assignments/media-types/application/vnd.lotus-freelance
application/vnd.lotus-notes http://www.iana.org/assignments/media-types/application/vnd.lotus-notes
application/vnd.lotus-organizer http://www.iana.org/assignments/media-types/application/vnd.lotus-organizer
application/vnd.lotus-screencam http://www.iana.org/assignments/media-types/application/vnd.lotus-screencam
application/vnd.lotus-wordpro http://www.iana.org/assignments/media-types/application/vnd.lotus-wordpro
application/vnd.mcd http://www.iana.org/assignments/media-types/application/vnd.mcd
application/vnd.mediastation.cdkey http://www.iana.org/assignments/media-types/application/vnd.mediastation.cdkey
application/vnd.meridian-slingshot http://www.iana.org/assignments/media-types/application/vnd.meridian-slingshot
application/vnd.micrografx.flo http://www.iana.org/assignments/media-types/application/vnd.micrografx.flo
application/vnd.micrografx.igx http://www.iana.org/assignments/media-types/application/vnd.micrografx-igx
application/vnd.mif http://www.iana.org/assignments/media-types/application/vnd-mif
application/vnd.minisoft-hp3000-save http://www.iana.org/assignments/media-types/application/vnd.minisoft-hp3000-save
application/vnd.mitsubishi.misty-guard.trustweb http://www.iana.org/assignments/media-types/application/vnd.mitsubishi.misty-guard.trustweb
application/vnd.Mobius.DAF http://www.iana.org/assignments/media-types/application/vnd.Mobius.DAF
application/vnd.Mobius.DIS http://www.iana.org/assignments/media-types/application/vnd.Mobius.DIS
application/vnd.Mobius.MBK http://www.iana.org/assignments/media-types/application/vnd.Mobius.MBK
application/vnd.Mobius.MQY http://www.iana.org/assignments/media-types/application/vnd.Mobius.MQY
application/vnd.Mobius.MSL http://www.iana.org/assignments/media-types/application/vnd.Mobius.MSL
application/vnd.Mobius.PLC http://www.iana.org/assignments/media-types/application/vnd.Mobius.PLC
application/vnd.Mobius.TXF http://www.iana.org/assignments/media-types/application/vnd.Mobius.TXF
application/vnd.mophun.application http://www.iana.org/assignments/media-types/application/vnd.mophun.application
application/vnd.mophun.certificate http://www.iana.org/assignments/media-types/application/vnd.mophun.certificate
application/vnd.motorola.flexsuite http://www.iana.org/assignments/media-types/application/vnd.motorola.flexsuite
application/vnd.motorola.flexsuite.adsi http://www.iana.org/assignments/media-types/application/vnd.motorola.flexsuite.adsi
application/vnd.motorola.flexsuite.fis http://www.iana.org/assignments/media-types/application/vnd.motorola.flexsuite.fis
application/vnd.motorola.flexsuite.gotap http://www.iana.org/assignments/media-types/application/vnd.motorola.flexsuite.gotap
application/vnd.motorola.flexsuite.kmr http://www.iana.org/assignments/media-types/application/vnd.motorola.flexsuite.kmr
application/vnd.motorola.flexsuite.ttc http://www.iana.org/assignments/media-types/application/vnd.motorola.flexsuite.ttc
application/vnd.motorola.flexsuite.wem http://www.iana.org/assignments/media-types/application/vnd.motorola.flexsuite.wem
application/vnd.mozilla.xul+xml http://www.iana.org/assignments/media-types/application/vnd.mozilla.xul+xml
application/vnd.ms-artgalry http://www.iana.org/assignments/media-types/application/vnd.ms-artgalry
application/vnd.ms-asf http://www.iana.org/assignments/media-types/application/vnd.ms-asf
application/vnd.mseq http://www.iana.org/assignments/media-types/application/vnd.mseq
application/vnd.ms-excel http://www.iana.org/assignments/media-types/application/vnd.ms-excel
application/vnd.msign http://www.iana.org/assignments/media-types/application/vnd.msign
application/vnd.ms-lrm http://www.iana.org/assignments/media-types/application/vnd.ms-lrm
application/vnd.ms-powerpoint http://www.iana.org/assignments/media-types/application/vnd.ms-powerpoint
application/vnd.ms-project http://www.iana.org/assignments/media-types/application/vnd.ms-project
application/vnd.ms-tnef http://www.iana.org/assignments/media-types/application/vnd.ms-tnef
application/vnd.ms-works http://www.iana.org/assignments/media-types/application/vnd.ms-works
application/vnd.ms-wpl http://www.iana.org/assignments/media-types/application/vnd.ms-wpl
application/vnd.musician http://www.iana.org/assignments/media-types/application/vnd.musician
application/vnd.music-niff http://www.iana.org/assignments/media-types/application/vnd.music-niff
application/vnd.nervana http://www.iana.org/assignments/media-types/application/vnd.nervana
application/vnd.netfpx http://www.iana.org/assignments/media-types/application/vnd.netfpx
application/vnd.noblenet-directory http://www.iana.org/assignments/media-types/application/vnd.noblenet-directory
application/vnd.noblenet-sealer http://www.iana.org/assignments/media-types/application/vnd.noblenet-sealer
application/vnd.noblenet-web http://www.iana.org/assignments/media-types/application/vnd.noblenet-web
application/vnd.novadigm.EDM http://www.iana.org/assignments/media-types/application/vnd.novadigm.EDM
application/vnd.novadigm.EDX http://www.iana.org/assignments/media-types/application/vnd.novadigm.EDX
application/vnd.novadigm.EXT http://www.iana.org/assignments/media-types/application/vnd.novadigm.EXT
application/vnd.obn http://www.iana.org/assignments/media-types/application/vnd.obn
application/vnd.osa.netdeploy http://www.iana.org/assignments/media-types/application/vnd.osa.netdeploy
application/vnd.palm http://www.iana.org/assignments/media-types/application/vnd.palm
application/vnd.paos.xml http://www.iana.org/assignments/media-types/application/vnd.paos+xml
application/vnd.pg.format http://www.iana.org/assignments/media-types/application/vnd.pg.format
application/vnd.picsel http://www.iana.org/assignments/media-types/application/vnd.picsel
application/vnd.pg.osasli http://www.iana.org/assignments/media-types/application/vnd.pg.osasli
application/vnd.powerbuilder6 http://www.iana.org/assignments/media-types/application/vnd.powerbuilder6
application/vnd.powerbuilder6-s http://www.iana.org/assignments/media-types/application/vnd.powerbuilder6-s
application/vnd.powerbuilder7 http://www.iana.org/assignments/media-types/application/vnd.powerbuilder7
application/vnd.powerbuilder75 http://www.iana.org/assignments/media-types/application/vnd.powerbuilder75
application/vnd.powerbuilder75-s http://www.iana.org/assignments/media-types/application/vnd.powerbuilder75-s
application/vnd.powerbuilder7-s http://www.iana.org/assignments/media-types/application/vnd.powerbuilder7-s
application/vnd.previewsystems.box http://www.iana.org/assignments/media-types/application/vnd.previewsystems.box
application/vnd.publishare-delta-tree http://www.iana.org/assignments/media-types/application/vnd.publishare-delta-tree
application/vnd.pvi.ptid1 http://www.iana.org/assignments/media-types/application/vnd.pvi.ptid1
application/vnd.pwg-multiplexed http://www.rfc-editor.org/rfc/rfc3391.txt
application/vnd.pwg-xhtml-print+xml http://www.iana.org/assignments/media-types/application/vnd.pwg-xhtml-print+xml
application/vnd.Quark.QuarkXPress http://www.iana.org/assignments/media-types/application/vnd.Quark.QuarkXPress
application/vnd.rapid http://www.iana.org/assignments/media-types/application/vnd.rapid
application/vnd.s3sms http://www.iana.org/assignments/media-types/application/vnd.s3sms
application/vnd.sealed.doc http://www.iana.org/assignments/media-types/application/vnd.sealed-doc
application/vnd.sealed.eml http://www.iana.org/assignments/media-types/application/vnd.sealed-eml
application/vnd.sealed.mht http://www.iana.org/assignments/media-types/application/vnd.sealed-mht
application/vnd.sealed.net http://www.iana.org/assignments/media-types/application/vnd.sealed.net
application/vnd.sealed.ppt http://www.iana.org/assignments/media-types/application/vnd.sealed-ppt
application/vnd.sealed.xls http://www.iana.org/assignments/media-types/application/vnd.sealed-xls
application/vnd.sealedmedia.softseal.html http://www.iana.org/assignments/media-types/application/vnd.sealedmedia.softseal-html
application/vnd.sealedmedia.softseal.pdf http://www.iana.org/assignments/media-types/application/vnd.sealedmedia.softseal-pdf
application/vnd.seemail http://www.iana.org/assignments/media-types/application/vnd.seemail
application/vnd.shana.informed.formdata http://www.iana.org/assignments/media-types/application/vnd.shana.informed.formdata
application/vnd.shana.informed.formtemplate http://www.iana.org/assignments/media-types/application/vnd.shana.informed.formtemplate
application/vnd.shana.informed.interchange http://www.iana.org/assignments/media-types/application/vnd.shana.informed.interchange
application/vnd.shana.informed.package http://www.iana.org/assignments/media-types/application/vnd.shana.informed.package
application/vnd.smaf http://www.iana.org/assignments/media-types/application/vnd.smaf
application/vnd.sss-cod http://www.iana.org/assignments/media-types/application/vnd.sss-cod
application/vnd.sss-dtf http://www.iana.org/assignments/media-types/application/vnd.sss-dtf
application/vnd.sss-ntf http://www.iana.org/assignments/media-types/application/vnd.sss-ntf
application/vnd.street-stream http://www.iana.org/assignments/media-types/application/vnd.street-stream
application/vnd.svd http://www.iana.org/assignments/media-types/application/vnd.svd
application/vnd.swiftview-ics http://www.iana.org/assignments/media-types/application/vnd.swiftview-ics
application/vnd.triscape.mxs http://www.iana.org/assignments/media-types/application/vnd.triscape.mxs
application/vnd.trueapp http://www.iana.org/assignments/media-types/application/vnd.trueapp
application/vnd.truedoc http://www.iana.org/assignments/media-types/application/vnd.truedoc
application/vnd.ufdl http://www.iana.org/assignments/media-types/application/vnd.ufdl
application/vnd.uiq.theme http://www.iana.org/assignments/media-types/application/vnd.uiq.theme
application/vnd.uplanet.alert http://www.iana.org/assignments/media-types/application/vnd.uplanet.alert
application/vnd.uplanet.alert-wbxml http://www.iana.org/assignments/media-types/application/vnd.uplanet.alert-wbxml
application/vnd.uplanet.bearer-choice http://www.iana.org/assignments/media-types/application/vnd.uplanet.bearer-choice
application/vnd.uplanet.bearer-choice-wbxml http://www.iana.org/assignments/media-types/application/vnd.uplanet.bearer-choice-wbxml
application/vnd.uplanet.cacheop http://www.iana.org/assignments/media-types/application/vnd.uplanet.cacheop
application/vnd.uplanet.cacheop-wbxml http://www.iana.org/assignments/media-types/application/vnd.uplanet.cacheop-wbxml
application/vnd.uplanet.channel http://www.iana.org/assignments/media-types/application/vnd.uplanet.channel
application/vnd.uplanet.channel-wbxml http://www.iana.org/assignments/media-types/application/vnd.uplanet.channel-wbxml
application/vnd.uplanet.list http://www.iana.org/assignments/media-types/application/vnd.uplanet.list
application/vnd.uplanet.listcmd http://www.iana.org/assignments/media-types/application/vnd.uplanet.listcmd
application/vnd.uplanet.listcmd-wbxml http://www.iana.org/assignments/media-types/application/vnd.uplanet.listcmd-wbxml
application/vnd.uplanet.list-wbxml http://www.iana.org/assignments/media-types/application/vnd.uplanet.list-wbxml
application/vnd.uplanet.signal http://www.iana.org/assignments/media-types/application/vnd.uplanet.signal
application/vnd.vcx http://www.iana.org/assignments/media-types/application/vnd.vcx
application/vnd.vectorworks http://www.iana.org/assignments/media-types/application/vnd.vectorworks
application/vnd.vidsoft.vidconference http://www.iana.org/assignments/media-types/application/vnd.vidsoft.vidconference
application/vnd.visio http://www.iana.org/assignments/media-types/application/vnd.visio
application/vnd.visionary http://www.iana.org/assignments/media-types/application/vnd.visionary
application/vnd.vividence.scriptfile http://www.iana.org/assignments/media-types/application/vnd.vividence.scriptfile
application/vnd.vsf http://www.iana.org/assignments/media-types/application/vnd.vsf
application/vnd.wap.sic http://www.iana.org/assignments/media-types/application/vnd.wap.sic
application/vnd.wap.slc http://www.iana.org/assignments/media-types/application/vnd.wap-slc
application/vnd.wap.wbxml http://www.iana.org/assignments/media-types/application/vnd.wap-wbxml
application/vnd.wap.wmlc http://www.iana.org/assignments/media-types/application/vnd-wap-wmlc
application/vnd.wap.wmlscriptc http://www.iana.org/assignments/media-types/application/vnd.wap.wmlscriptc
application/vnd.webturbo http://www.iana.org/assignments/media-types/application/vnd.webturbo
application/vnd.wqd http://www.iana.org/assignments/media-types/application/vnd.wqd
application/vnd.wrq-hp3000-labelled http://www.iana.org/assignments/media-types/application/vnd.wrq-hp3000-labelled
application/vnd.wt.stf http://www.iana.org/assignments/media-types/application/vnd.wt.stf
application/vnd.wv.csp+xml http://www.iana.org/assignments/media-types/application/vnd.wv.csp+xml
application/vnd.wv.csp+wbxml http://www.iana.org/assignments/media-types/application/vnd.wv.csp+wbxml
application/vnd.wv.ssp+xml http://www.iana.org/assignments/media-types/application/vnd.wv.ssp+xml
application/vnd.xara http://www.iana.org/assignments/media-types/application/vnd.xara
application/vnd.xfdl http://www.iana.org/assignments/media-types/application/vnd.xfdl
application/vnd.yamaha.hv-dic http://www.iana.org/assignments/media-types/application/vnd.yamaha.hv-dic
application/vnd.yamaha.hv-script http://www.iana.org/assignments/media-types/application/vnd.yamaha.hv-script
application/vnd.yamaha.hv-voice http://www.iana.org/assignments/media-types/application/vnd.yamaha.hv-voice
application/vnd.yamaha.smaf-audio http://www.iana.org/assignments/media-types/application/vnd.yamaha.smaf-audio
application/vnd.yamaha.smaf-phrase http://www.iana.org/assignments/media-types/application/vnd.yamaha.smaf-phrase
application/vnd.yellowriver-custom-menu http://www.iana.org/assignments/media-types/application/vnd.yellowriver-custom-menu
application/whoispp-query http://www.rfc-editor.org/rfc/rfc2957.txt
application/whoispp-response http://www.rfc-editor.org/rfc/rfc2958.txt
application/wita http://www.iana.org/assignments/media-types/application/wita
application/wordperfect5.1 http://www.iana.org/assignments/media-types/application/wordperfect5.1
application/x400-bp http://www.rfc-editor.org/rfc/rfc1494.txt
application/x.atom+xml http://bitworking.org/projects/atom/draft-gregorio-09.html#rfc.section.5.4.4
application/xhtml+xml http://www.ietf.org/rfc/rfc3236.txt
application/xml http://www.rfc-editor.org/rfc/rfc3023.txt
application/xml-dtd http://www.rfc-editor.org/rfc/rfc3023.txt
application/xml-external-parsed-entity http://www.rfc-editor.org/rfc/rfc3023.txt
application/zip http://www.iana.org/assignments/media-types/application/zip
audio/32kadpcm http://www.rfc-editor.org/rfc/rfc2422.txt
audio/AMR http://www.rfc-editor.org/rfc/rfc3267.txt
audio/AMR-WB http://www.rfc-editor.org/rfc/rfc3267.txt
audio/basic http://www.rfc-editor.org/rfc/rfc2046.txt
audio/CN http://www.rfc-editor.org/rfc/rfc3389.txt
audio/DAT12 http://www.rfc-editor.org/rfc/rfc3190.txt
audio/dsr-es201108 http://www.rfc-editor.org/rfc/rfc3557.txt
audio/DVI4 http://www.rfc-editor.org/rfc/rfc3555.txt
audio/EVRC http://www.rfc-editor.org/rfc/rfc3558.txt
audio/EVRC0 http://www.rfc-editor.org/rfc/rfc3558.txt
audio/EVRC-QCP http://www.rfc-editor.org/rfc/rfc3625.txt
audio/G722 http://www.rfc-editor.org/rfc/rfc3555.txt
audio/G.722.1 http://www.rfc-editor.org/rfc/rfc3047.txt
audio/G723 http://www.rfc-editor.org/rfc/rfc3555.txt
audio/G726-16 http://www.rfc-editor.org/rfc/rfc3555.txt
audio/G726-24 http://www.rfc-editor.org/rfc/rfc3555.txt
audio/G726-32 http://www.rfc-editor.org/rfc/rfc3555.txt
audio/G726-40 http://www.rfc-editor.org/rfc/rfc3555.txt
audio/G728 http://www.rfc-editor.org/rfc/rfc3555.txt
audio/G729 http://www.rfc-editor.org/rfc/rfc3555.txt
audio/G729D http://www.rfc-editor.org/rfc/rfc3555.txt
audio/G729E http://www.rfc-editor.org/rfc/rfc3555.txt
audio/GSM http://www.rfc-editor.org/rfc/rfc3555.txt
audio/GSM-EFR http://www.rfc-editor.org/rfc/rfc3555.txt
audio/L8 http://www.rfc-editor.org/rfc/rfc3555.txt
audio/L16 http://www.rfc-editor.org/rfc/rfc3555.txt
audio/L20 http://www.rfc-editor.org/rfc/rfc3190.txt
audio/L24 http://www.rfc-editor.org/rfc/rfc3190.txt
audio/LPC http://www.rfc-editor.org/rfc/rfc3555.txt
audio/MPA http://www.rfc-editor.org/rfc/rfc3555.txt
audio/MP4A-LATM http://www.rfc-editor.org/rfc/rfc3016.txt
audio/mpa-robust http://www.rfc-editor.org/rfc/rfc3119.txt
audio/mpeg http://www.rfc-editor.org/rfc/rfc3003.txt
audio/mpeg4-generic http://www.rfc-editor.org/rfc/rfc3640.txt
audio/parityfec http://www.rfc-editor.org/rfc/rfc3009.txt
audio/PCMA http://www.rfc-editor.org/rfc/rfc3555.txt
audio/PCMU http://www.rfc-editor.org/rfc/rfc3555.txt
audio/prs.sid http://www.iana.org/assignments/media-types/audio/prs.sid
audio/QCELP http://www.rfc-editor.org/rfc/rfc3625.txt
audio/RED http://www.rfc-editor.org/rfc/rfc3555.txt
audio/SMV http://www.rfc-editor.org/rfc/rfc3558.txt
audio/SMV0 http://www.rfc-editor.org/rfc/rfc3558.txt
audio/SMV-QCP http://www.rfc-editor.org/rfc/rfc3625.txt
audio/telephone-event http://www.rfc-editor.org/rfc/rfc2833.txt
audio/tone http://www.rfc-editor.org/rfc/rfc2833.txt
audio/VDVI http://www.rfc-editor.org/rfc/rfcXXXX.txt
audio/vnd.3gpp.iufp http://www.iana.org/assignments/media-types/audio/vnd.3gpp.iufp
audio/vnd.cisco.nse http://www.iana.org/assignments/media-types/audio/vnd.cisco.nse
audio/vnd.cns.anp1 http://www.iana.org/assignments/media-types/audio/vnd.cns.anp1
audio/vnd.cns.inf1 http://www.iana.org/assignments/media-types/audio/vnd.cns.inf1
audio/vnd.digital-winds http://www.iana.org/assignments/media-types/audio/vnd.digital-winds
audio/vnd.everad.plj http://www.iana.org/assignments/media-types/audio/vnd.everad.plj
audio/vnd.lucent.voice http://www.iana.org/assignments/media-types/audio/vnd.lucent.voice
audio/vnd.nokia.mobile-xmf http://www.iana.org/assignments/media-types/audio/vnd.nokia.mobile-xmf
audio/vnd.nortel.vbk http://www.iana.org/assignments/media-types/audio/vnd.nortel.vbk
audio/vnd.nuera.ecelp4800 http://www.iana.org/assignments/media-types/audio/vnd.nuera.ecelp4800
audio/vnd.nuera.ecelp7470 http://www.iana.org/assignments/media-types/audio/vnd.nuera.ecelp7470
audio/vnd.nuera.ecelp9600 http://www.iana.org/assignments/media-types/audio/vnd.nuera.ecelp9600
audio/vnd.octel.sbc http://www.iana.org/assignments/media-types/audio/vnd.octel.sbc
audio/vnd.rhetorex.32kadpcm http://www.iana.org/assignments/media-types/audio/vnd.rhetorex.32kadpcm
audio/vnd.sealedmedia.softseal.mpeg http://www.iana.org/assignments/media-types/audio/vnd.sealedmedia.softseal-mpeg
audio/vnd.vmx.cvsd http://www.iana.org/assignments/media-types/audio/vnd.vmx.cvsd
image/cgm http://www.iana.org/assignments/media-types/image/cgm
image/g3fax http://www.rfc-editor.org/rfc/rfc1494.txt
image/gif http://www.rfc-editor.org/rfc/rfc2046.txt
image/ief http://www.rfc-editor.org/rfc/rfc1314.txt
image/jp2 http://www.iana.org/assignments/media-types/image/jp2
image/jpeg http://www.rfc-editor.org/rfc/rfc2046.txt
image/jpm http://www.iana.org/assignments/media-types/image/jpm
image/jpx http://www.iana.org/assignments/media-types/image/jpx
image/naplps http://www.iana.org/assignments/media-types/image/naplps
image/png http://www.iana.org/assignments/media-types/image/png
image/prs.btif http://www.iana.org/assignments/media-types/image/prs.btif
image/prs.pti http://www.iana.org/assignments/media-types/image/prs.pti
image/t38 http://www.rfc-editor.org/rfc/rfc3362.txt
image/tiff http://www.rfc-editor.org/rfc/rfc2302.txt
image/tiff-fx http://www.rfc-editor.org/rfc/rfc3250.txt
image/vnd.cns.inf2 http://www.iana.org/assignments/media-types/image/vnd.cns.inf2
image/vnd.djvu http://www.iana.org/assignments/media-types/image/vnd.djvu
image/vnd.dwg http://www.iana.org/assignments/media-types/image/vnd.dwg
image/vnd.dxf http://www.iana.org/assignments/media-types/image/vnd.dxf
image/vnd.fastbidsheet http://www.iana.org/assignments/media-types/image/vnd.fastbidsheet
image/vnd.fpx http://www.iana.org/assignments/media-types/image/vnd.fpx
image/vnd.fst http://www.iana.org/assignments/media-types/image/vnd.fst
image/vnd.fujixerox.edmics-mmr http://www.iana.org/assignments/media-types/image/vnd.fujixerox.edmics-mmr
image/vnd.fujixerox.edmics-rlc http://www.iana.org/assignments/media-types/image/vnd.fujixerox.edmics-rlc
image/vnd.globalgraphics.pgb http://www.iana.org/assignments/media-types/image/vnd.globalgraphics.pgb
image/vnd.microsoft.icon http://www.iana.org/assignments/media-types/image/vnd.microsoft.icon
image/vnd.mix http://www.iana.org/assignments/media-types/image/vnd.mix
image/vnd.ms-modi http://www.iana.org/assignments/media-types/image/vnd.ms-modi
image/vnd.net-fpx http://www.iana.org/assignments/media-types/image/vnd.net-fpx
image/vnd.sealed.png http://www.iana.org/assignments/media-types/image/vnd.sealed-png
image/vnd.sealedmedia.softseal.gif http://www.iana.org/assignments/media-types/image/vnd.sealedmedia.softseal-gif
image/vnd.sealedmedia.softseal.jpg http://www.iana.org/assignments/media-types/image/vnd.sealedmedia.softseal-jpg
image/vnd.svf http://www.iana.org/assignments/media-types/image/vnd-svf
image/vnd.wap.wbmp http://www.iana.org/assignments/media-types/image/vnd-wap-wbmp
image/vnd.xiff http://www.iana.org/assignments/media-types/image/vnd.xiff
message/delivery-status http://www.rfc-editor.org/rfc/rfc1894.txt
message/disposition-notification http://www.rfc-editor.org/rfc/rfc2298.txt
message/external-body http://www.rfc-editor.org/rfc/rfc2046.txt
message/http http://www.rfc-editor.org/rfc/rfc2616.txt
message/news http://www.rfc-editor.org/rfc/rfc1036.txt
message/partial http://www.rfc-editor.org/rfc/rfc2046.txt
message/rfc822 http://www.rfc-editor.org/rfc/rfc2046.txt
message/s-http http://www.rfc-editor.org/rfc/rfc2660.txt
message/sip http://www.rfc-editor.org/rfc/rfc3261.txt
message/sipfrag http://www.rfc-editor.org/rfc/rfc3420.txt
model/iges http://www.iana.org/assignments/media-types/model/iges
model/mesh http://www.rfc-editor.org/rfc/rfc2077.txt
model/vnd.dwf http://www.iana.org/assignments/media-types/model/vnd-dwf
model/vnd.flatland.3dml http://www.iana.org/assignments/media-types/model/vnd.flatland.3dml
model/vnd.gdl http://www.iana.org/assignments/media-types/model/vnd.gdl
model/vnd.gs-gdl http://www.iana.org/assignments/media-types/model/vnd.gs-gdl
model/vnd.gtw http://www.iana.org/assignments/media-types/model/vnd.gtw
model/vnd.mts http://www.iana.org/assignments/media-types/model/vnd.mts
model/vnd.parasolid.transmit.binary http://www.iana.org/assignments/media-types/model/vnd.parasolid.transmit-binary
model/vnd.parasolid.transmit.text http://www.iana.org/assignments/media-types/model/vnd.parasolid.transmit-text
model/vnd.vtu http://www.iana.org/assignments/media-types/model/vnd.vtu
model/vrml http://www.rfc-editor.org/rfc/rfc2077.txt
multipart/alternative http://www.rfc-editor.org/rfc/rfc2046.txt
multipart/appledouble http://www.iana.org/assignments/media-types/multipart/appledouble
multipart/byteranges http://www.rfc-editor.org/rfc/rfc2068.txt
multipart/digest http://www.rfc-editor.org/rfc/rfc2046.txt
multipart/encrypted http://www.rfc-editor.org/rfc/rfc1847.txt
multipart/form-data http://www.rfc-editor.org/rfc/rfc2388.txt
multipart/header-set http://www.iana.org/assignments/media-types/multipart/header-set
multipart/mixed http://www.rfc-editor.org/rfc/rfc2046.txt
multipart/parallel http://www.rfc-editor.org/rfc/rfc2046.txt
multipart/related http://www.rfc-editor.org/rfc/rfc2387.txt
multipart/report http://www.rfc-editor.org/rfc/rfc1892.txt
multipart/signed http://www.rfc-editor.org/rfc/rfc1847.txt
multipart/voice-message http://www.rfc-editor.org/rfc/rfc2423.txt
text/calendar http://www.rfc-editor.org/rfc/rfc2445.txt
text/css http://www.rfc-editor.org/rfc/rfc2318.txt
text/directory http://www.rfc-editor.org/rfc/rfc2425.txt
text/enriched http://www.rfc-editor.org/rfc/rfc1896.txt
text/html http://www.rfc-editor.org/rfc/rfc2854.txt
text/parityfec http://www.rfc-editor.org/rfc/rfc3009.txt
text/plain http://www.rfc-editor.org/rfc/rfc3676.txt
text/prs.fallenstein.rst http://www.iana.org/assignments/media-types/text/prs.fallenstein.rst
text/prs.lines.tag http://www.iana.org/assignments/media-types/text/prs.lines.tag
text/rfc822-headers http://www.rfc-editor.org/rfc/rfc1892.txt
text/richtext http://www.rfc-editor.org/rfc/rfc2046.txt
text/rtf http://www.iana.org/assignments/media-types/text/rtf
text/sgml http://www.rfc-editor.org/rfc/rfc1874.txt
text/t140 http://www.rfc-editor.org/rfc/rfc2793.txt
text/tab-separated-values http://www.iana.org/assignments/contact-people.htm#Lindner
text/uri-list http://www.rfc-editor.org/rfc/rfc2483.txt
text/vnd.abc http://www.iana.org/assignments/media-types/text/vnd.abc
text/vnd.curl http://www.iana.org/assignments/media-types/text/vnd-curl
text/vnd.DMClientScript http://www.iana.org/assignments/media-types/text/vnd.DMClientScript
text/vnd.fly http://www.iana.org/assignments/media-types/text/vnd.fly
text/vnd.fmi.flexstor http://www.iana.org/assignments/media-types/text/vnd.fmi.flexstor
text/vnd.in3d.3dml http://www.iana.org/assignments/media-types/text/vnd.in3d.3dml
text/vnd.in3d.spot http://www.iana.org/assignments/media-types/text/vnd.in3d.spot
text/vnd.latex-z http://www.iana.org/assignments/media-types/text/vnd.latex-z
text/vnd.motorola.reflex http://www.iana.org/assignments/media-types/text/vnd.motorola.reflex
text/vnd.ms-mediapackage http://www.iana.org/assignments/media-types/text/vnd.ms-mediapackage
text/vnd.net2phone.commcenter.command http://www.iana.org/assignments/media-types/text/vnd.net2phone.commcenter.command
text/vnd.sun.j2me.app-descriptor http://www.iana.org/assignments/media-types/text/vnd.sun.j2me.app-descriptor
text/vnd.wap.si http://www.iana.org/assignments/media-types/text/vnd.wap.si
text/vnd.wap.sl http://www.iana.org/assignments/media-types/text/vnd.wap.sl
text/vnd.wap.wml http://www.iana.org/assignments/media-types/text/vnd.wap-wml
text/vnd.wap.wmlscript http://www.iana.org/assignments/media-types/text/vnd.wap.wmlscript
text/xml http://www.rfc-editor.org/rfc/rfc3023.txt
text/xml-external-parsed-entity http://www.rfc-editor.org/rfc/rfc3023.txt
video/BMPEG http://www.rfc-editor.org/rfc/rfc3555.txt
video/BT656 http://www.rfc-editor.org/rfc/rfc3555.txt
video/CelB http://www.rfc-editor.org/rfc/rfc3555.txt
video/DV http://www.rfc-editor.org/rfc/rfc3189.txt
video/H261 http://www.rfc-editor.org/rfc/rfc3555.txt
video/H263 http://www.rfc-editor.org/rfc/rfc3555.txt
video/H263-1998 http://www.rfc-editor.org/rfc/rfc3555.txt
video/H263-2000 http://www.rfc-editor.org/rfc/rfc3555.txt
video/JPEG http://www.rfc-editor.org/rfc/rfc3555.txt
video/MJ2 http://www.iana.org/assignments/media-types/video/mj2
video/MP1S http://www.rfc-editor.org/rfc/rfc3555.txt
video/MP2P http://www.rfc-editor.org/rfc/rfc3555.txt
video/MP2T http://www.rfc-editor.org/rfc/rfc3555.txt
video/MP4V-ES http://www.rfc-editor.org/rfc/rfc3016.txt
video/MPV http://www.rfc-editor.org/rfc/rfc3555.txt
video/mpeg http://www.rfc-editor.org/rfc/rfc2046.txt
video/mpeg4-generic http://www.rfc-editor.org/rfc/rfc3640.txt
video/nv http://www.rfc-editor.org/rfc/rfc3555.txt
video/parityfec http://www.rfc-editor.org/rfc/rfc3009.txt
video/pointer http://www.rfc-editor.org/rfc/rfc2862.txt
video/quicktime http://www.iana.org/assignments/media-types/video/quicktime
video/SMPTE292M http://www.rfc-editor.org/rfc/rfc3497.txt
video/vnd.fvt http://www.iana.org/assignments/media-types/video/vnd.fvt
video/vnd.motorola.video http://www.iana.org/assignments/media-types/video/vnd.motorola.video
video/vnd.motorola.videop http://www.iana.org/assignments/media-types/video/vnd.motorola.videop
video/vnd.mpegurl http://www.iana.org/assignments/media-types/video/vnd-mpegurl
video/vnd.nokia.interleaved-multimedia http://www.iana.org/assignments/media-types/video/vnd.nokia.interleaved-multimedia
video/vnd.objectvideo http://www.iana.org/assignments/media-types/video/vnd.objectvideo
video/vnd.sealed.mpeg1 http://www.iana.org/assignments/media-types/video/vnd.sealed.mpeg1
video/vnd.sealed.mpeg4 http://www.iana.org/assignments/media-types/video/vnd.sealed.mpeg4
video/vnd.sealed.swf http://www.iana.org/assignments/media-types/video/vnd.sealed-swf
video/vnd.sealedmedia.softseal.mov http://www.iana.org/assignments/media-types/video/vnd.sealedmedia.softseal-mov
video/vnd.vivo http://www.iana.org/assignments/media-types/video/vnd-vivo"))
			{
				string line = String.Empty;
				string type = String.Empty;
				int i = 0;

				line = reader.ReadLine();
				while(line != null)
				{
					type = line.Split(new char[] {' '}, 2)[0];
					_mediaTypes.Add(i, type);
					i++;
					line = reader.ReadLine();
				}
			}
            
		}
		#endregion
		
		#region Public methods

		/// <summary>
		/// Escapes the given <see cref="String"/>.
		/// </summary>
		/// <param name="buffer">The <see cref="String"/> to escape.</param>
		/// <returns>The escaped <see cref="String"/>.</returns>
		public static string Escape(string buffer)
		{
			return HttpUtility.HtmlEncode(buffer);
		}

		/// <summary>
		/// Unescapes the given <see cref="String"/>.
		/// </summary>
		/// <param name="buffer">The <see cref="String"/> to unescape.</param>
		/// <returns>The unescaped <see cref="String"/>.</returns>
		public static string Unescape(string buffer)
		{
			return HttpUtility.HtmlDecode(buffer);
		}

		/// <summary>
		/// Base64-encodes the given byte array.
		/// </summary>
		/// <param name="array">The byte array to encode.</param>
		/// <returns>A base64-encoded string.</returns>
		public static string Base64Encode(byte[] array)
		{
			return Convert.ToBase64String(array);
		}

		/// <summary>
		/// Base64-encodes the given byte array from the given offset to "len" number of bytes.
		/// </summary>
		/// <param name="array">The byte array to encode.</param>
		/// <param name="offset">The offset from which the encoding starts.</param>
		/// <param name="length">The number of bytes from the offset to encode.</param>
		/// <returns>A base64-encoded string.</returns>
		public static string Base64Encode(byte[] array, int offset, int length)
		{
			return Convert.ToBase64String(array, offset, length);
		}

		/// <summary>
		/// Base64-encodes the given <see cref="String"/>.
		/// </summary>
		/// <param name="buffer">The string to encode.</param>
		/// <returns>A base64-encoded string.</returns>
		public static string Base64Encode(string buffer)
		{
			byte[] arr = Encoding.ASCII.GetBytes(buffer);
			return Base64Encode(arr);
		}

		/// <summary>
		/// Base64-decodes the given byte array.
		/// </summary>
		/// <param name="array">The byte array to decode.</param>
		/// <returns>A base64-decoded array of bytes.</returns>
		public static byte[] Base64Decode(char[] array)
		{
			return Convert.FromBase64CharArray(array, 0, array.Length);
		}

		/// <summary>
		/// Base64-decodes the given byte array from the given offset to "len" number of bytes.
		/// </summary>
		/// <param name="array">The byte array to decode.</param>
		/// <param name="offset">The offset from which the decoding starts.</param>
		/// <param name="length">The number of bytes from the offset to decode.</param>
		/// <returns>A base64-encoded array of bytes.</returns>
		public static byte[] Base64Decode(char[] array, int offset, int length)
		{
			return Convert.FromBase64CharArray(array, offset, length);
		}

		/// <summary>
		/// Base64-decodes the given <see cref="String"/>.
		/// </summary>
		/// <param name="buffer">The string to decode.</param>
		/// <returns>A base64-decoded array of bytes.</returns>
		public static byte[] Base64Decode(string buffer)
		{
			return Convert.FromBase64String(buffer);
		}

		/// <summary>
		/// Checks if the given string representation of a date matches the ISO 8601 format.
		/// </summary>
		/// <param name="theDate">The datetime to check.</param>
		/// <returns>true if the given date is in ISO 8601 format, false otherwise.</returns>
		public static bool IsIso8601Date(string theDate)
		{
			string regExp = @"\d\d\d\d(-\d\d(-\d\d(T\d\d:\d\d(:\d\d(\.\d*)?)?(Z|([+-]\d\d:\d\d))?)?)?)?$";

            Regex rx = new Regex(regExp, RegexOptions.IgnoreCase);
			if(rx.IsMatch(theDate))
				return true;

			return false;
		}

		/// <summary>
		/// Checks if the given string representation of a date matches the ISO 8601 format with the UTC time zone.
		/// </summary>
		/// <param name="theDate">The datetime to check.</param>
		/// <returns>true if the given date is in ISO 8601 format with the UTC time zone, false otherwise.</returns>
		public static bool IsIso8601DateTZ(string theDate)
		{
			if(IsIso8601Date(theDate))
			{
				string regExp = @"Z|([+-]\d\d:\d\d)$";

				Regex rx = new Regex(regExp, RegexOptions.IgnoreCase | RegexOptions.Multiline);
				if(rx.IsMatch(theDate))
					return true;
				else if(theDate.IndexOf('Z') != -1)
					return true;
			}

			return false;
		}

		/// <summary>
		/// Checks if the given string representation of a date matches the ISO 8601 format without the UTC time zone.
		/// </summary>
		/// <param name="theDate">The datetime to check.</param>
		/// <returns>true if the given date is in ISO 8601 format with the UTC time zone, false otherwise.</returns>
		public static bool IsIso8601DateLocalNoTZ(string theDate)
		{
			bool val = IsIso8601DateTZ(theDate);
			
			return !val;
		}

		/// <summary>
		/// Checks if the given string representation of a date matches the ISO 8601 format with a local time zone.
		/// </summary>
		/// <param name="theDate">The datetime to check.</param>
		/// <returns>true if the given date is in ISO 8601 format with a local time zone, false otherwise.</returns>
		public static bool IsIso8601DateLocal(string theDate)
		{
			if(IsIso8601Date(theDate))
			{
				if(theDate.IndexOf('Z') != -1)
					return false;

				return true;
			}

			return false;
		}

		/// <summary>
		/// Checks if the given parameter is a valid email address.
		/// </summary>
		/// <param name="email">The email to check.</param>
		/// <returns>true if the given email is valid, false otherwise.</returns>
		public static bool IsEmail(string email)
		{
			string regExp = @"([a-zA-Z0-9_\-\+\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

			Regex rx = new Regex(regExp, RegexOptions.IgnoreCase | RegexOptions.Multiline);
			if(rx.IsMatch(email))
				return true;

			return false;
		}

		/// <summary>
		/// Gets the versions of the library.
		/// </summary>
		/// <returns>The major, minor, revision and build numbers for the library.</returns>
		public static string GetVersion()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			return assembly.GetName().Version.ToString();
		}

		#endregion

		#region Internal methods

		/// <summary>
		/// Parses the <see cref="Relationship"/> enum.
		/// </summary>
		/// <param name="rel">The relationship value to parse.</param>
		/// <returns>The string representation of the relationship value.</returns>
		internal static string ParseRelationship(Relationship rel)
		{
			string val = String.Empty;

			switch(rel)
			{
				case Relationship.Alternate:
					val = "alternate";
					break;

				case Relationship.Next:
					val = "next";
					break;

				case Relationship.Prev:
					val = "prev";
					break;

				case Relationship.ServiceEdit:
					val = "service.edit";
					break;

				case Relationship.ServiceFeed:
					val = "service.feed";
					break;

				case Relationship.ServicePost:
					val = "service.post";
					break;

				case Relationship.Start:
					val = "start";
					break;
			}
			
			return val;
		}

		/// <summary>
		/// Parses a rel attribute.
		/// </summary>
		/// <param name="rel">The relationship value to parse.</param>
		/// <returns>The enum value of the given relationship string.</returns>
		internal static Relationship ParseRelationship(string rel)
		{
			switch(rel)
			{
				case "alternate":
					return Relationship.Alternate;

				case "next":
					return Relationship.Next;

				case "prev":
					return Relationship.Prev;

				case "service.edit":
					return Relationship.ServiceEdit;

				case "service.feed":
					return Relationship.ServiceFeed;

				case "service.post":
					return Relationship.ServicePost;

				case "start":
					return Relationship.Start;

				default:
					return Relationship.Alternate;
			}
		}

		/// <summary>
		/// Parses the <see cref="MediaType"/> enum.
		/// </summary>
		/// <param name="type">The media type to parse.</param>
		/// <returns>The string representation of the media type.</returns>
		internal static string ParseMediaType(MediaType type)
		{
			string val = String.Empty;

			try
			{
				val = (string) _mediaTypes[Convert.ToInt32(type)];
			}
			catch
			{
				val = "text/plain";
			}
			
			return val;
		}

		/// <summary>
		/// Parses a media type string.
		/// </summary>
		/// <param name="type">The media type to parse.</param>
		/// <returns>The enum value of the given media type.</returns>
		internal static MediaType ParseMediaType(string type)
		{
			if(_mediaTypes.ContainsValue(type))
			{
				MediaType mtype = MediaType.UnknownType;
				foreach(DictionaryEntry entry in _mediaTypes)
				{
					string val = (string) entry.Value;
					if(val == type)
					{
						try
						{
							int key = Convert.ToInt32(entry.Key.ToString());
							mtype = (MediaType) key;
						}
						catch
						{
							return MediaType.UnknownType;
						}
					}
				}
				return mtype;
			}
			return MediaType.UnknownType;
		}

		/// <summary>
		/// Parses the <see cref="Language"/> enum.
		/// </summary>
		/// <param name="lang">The language to parse.</param>
		/// <returns>The string representation of the language.</returns>
		internal static string ParseLanguage(Language lang)
		{
			if(lang == Language.UnknownLanguage)
				return String.Empty;

			return lang.ToString().Replace("_", "-");
		}

		/// <summary>
		/// Parses the string representation of a language
		/// </summary>
		/// <param name="lang">The language to parse.</param>
		/// <returns>The <see cref="Language"/> enum value.</returns>
		internal static Language ParseLanguage(string lang)
		{
			if(lang != null && lang.Length > 0)
			{
				string temp = lang.Replace("-", "_");
				return (Language) Enum.Parse(typeof(Language), temp, true);
			}
			return Language.UnknownLanguage;
		}

		#endregion
	}
}