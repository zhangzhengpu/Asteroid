#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)
#pragma warning disable
using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
    /**
     * <code>UserNotice</code> class, used in
     * <code>CertificatePolicies</code> X509 extensions (in policy
     * qualifiers).
     * <pre>
     * UserNotice ::= Sequence {
     *      noticeRef        NoticeReference OPTIONAL,
     *      explicitText     DisplayText OPTIONAL}
     *
     * </pre>
     *
     * @see PolicyQualifierId
     * @see PolicyInformation
     */
    public class UserNotice
        : Asn1Encodable
    {
        private readonly NoticeReference noticeRef;
        private readonly DisplayText explicitText;

        /**
         * Creates a new <code>UserNotice</code> instance.
         *
         * @param noticeRef a <code>NoticeReference</code> value
         * @param explicitText a <code>DisplayText</code> value
         */
        public UserNotice(
            NoticeReference	noticeRef,
            DisplayText		explicitText)
        {
            this.noticeRef = noticeRef;
            this.explicitText = explicitText;
        }

        /**
         * Creates a new <code>UserNotice</code> instance.
         *
         * @param noticeRef a <code>NoticeReference</code> value
         * @param str the explicitText field as a string.
         */
        public UserNotice(
            NoticeReference	noticeRef,
            string			str)
            : this(noticeRef, new DisplayText(str))
        {
        }

        /**
         * Creates a new <code>UserNotice</code> instance.
         * <p>Useful from reconstructing a <code>UserNotice</code> instance
         * from its encodable/encoded form.
         *
         * @param as an <code>ASN1Sequence</code> value obtained from either
         * calling @{link toASN1Object()} for a <code>UserNotice</code>
         * instance or from parsing it from a DER-encoded stream.</p>
         */
        [Obsolete("Use GetInstance() instead")]
        public UserNotice(
            Asn1Sequence seq)
        {
            if (seq.Count == 2)
            {
                noticeRef = NoticeReference.GetInstance(seq[0]);
                explicitText = DisplayText.GetInstance(seq[1]);
            }
            else if (seq.Count == 1)
            {
                if (seq[0].ToAsn1Object() is Asn1Sequence)
                {
                    noticeRef = NoticeReference.GetInstance(seq[0]);
                    explicitText = null;
                }
                else
                {
                    noticeRef = null;
                    explicitText = DisplayText.GetInstance(seq[0]);
                }
            }
            else if (seq.Count == 0)
            {
                noticeRef = null;       // neither field set!
                explicitText = null;
            }
            else
            {
                throw new ArgumentException("Bad sequence size: " + seq.Count);
            }
        }

        public static UserNotice GetInstance(object obj)
        {
            if (obj is UserNotice)
                return (UserNotice)obj;
            if (obj == null)
                return null;
            return new UserNotice(Asn1Sequence.GetInstance(obj));
        }

        public virtual NoticeReference NoticeRef
        {
            get { return noticeRef; }
        }

        public virtual DisplayText ExplicitText
        {
            get { return explicitText; }
        }

        public override Asn1Object ToAsn1Object()
        {
            Asn1EncodableVector av = new Asn1EncodableVector();

            if (noticeRef != null)
            {
                av.Add(noticeRef);
            }

            if (explicitText != null)
            {
                av.Add(explicitText);
            }

            return new DerSequence(av);
        }
    }
}
#pragma warning restore
#endif
