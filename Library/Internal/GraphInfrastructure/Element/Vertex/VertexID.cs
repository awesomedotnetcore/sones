﻿using System;

namespace sones.GraphInfrastructure.Element
{
    /// <summary>
    /// The id of a vertex. It consists of a Guid and an vertex-type-name
    /// </summary>
    public sealed class VertexID
    {
        #region Data

        /// <summary>
        /// The type-global-id of the vertex
        /// </summary>
        readonly public String VertexName;

        /// <summary>
        /// The name of the vertex type
        /// </summary>
        readonly public String VertexTypeName;

        /// <summary>
        /// The hashcode of the VertexID
        /// </summary>
        readonly private int _hashCode = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new VertexID.
        /// A VertexID consists of a vertex type name and a vertex name
        /// </summary>
        /// <param name="myTypeName">The vertex type name</param>
        /// <param name="myVertexID">The vertex name (if left out, a name will be generated)</param>
        public VertexID(String myTypeName, String myVertexName = null)
        {
            if (myVertexName != null)
            {
                VertexName = myVertexName;
            }
            else
            {
                VertexName = Guid.NewGuid().ToString();
            }

            VertexTypeName = myTypeName;

            _hashCode = VertexName.GetHashCode() ^ VertexTypeName.GetHashCode();
        }

        #endregion

        #region Equals Overrides

        public override Boolean Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            VertexID v = obj as VertexID;

            if (v != null)
            {
                return Equals(v);
            }
            else
            {
                return false;
            }
        }

        public Boolean Equals(VertexID myVertex)
        {
            if ((object)myVertex == null)
            {
                return false;
            }

            return (this.VertexName == myVertex.VertexName) && (this.VertexTypeName == myVertex.VertexTypeName);
        }

        public static Boolean operator ==(VertexID aVertex, VertexID bVertex)
        {
            if (Object.ReferenceEquals(aVertex, bVertex))
            {
                return true;
            }

            if (((object)aVertex == null) || ((object)bVertex == null))
            {
                return false;
            }

            return aVertex.Equals(bVertex);
        }

        public static Boolean operator !=(VertexID aVertex, VertexID bVertex)
        {
            return !(aVertex == bVertex);
        }

        public override int GetHashCode()
        {
            return _hashCode;
        }

        #endregion
    }
}