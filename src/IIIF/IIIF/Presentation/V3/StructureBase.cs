﻿using System;
using System.Collections.Generic;
using IIIF.Presentation.V3.Annotation;
using Newtonsoft.Json;

namespace IIIF.Presentation.V3
{
    /// <summary>
    /// Base class for resources that form the structure of a IIIF resource:
    /// Manifest, Canvas, Collection, Range
    /// See <a href="https://iiif.io/api/presentation/3.0/#21-defined-types">Defined Types</a> for more information.
    /// </summary>
    public abstract class StructureBase : ResourceBase
    {
        private DateTime? navDateInternal;

        /// <summary>
        /// You can't always set a navDate as a DateTime/
        /// Not serialised.
        /// </summary>
        /// TODO - mark as not serialisable
        public DateTime? NavDateDateTime 
        {
            get => navDateInternal;
            set
            {
                navDateInternal = value;
                NavDate = navDateInternal?.ToString("o");
            }
        }
        
        /// <summary>
        /// A date that clients may use for navigation purposes.
        /// See <a href="https://iiif.io/api/presentation/3.0/#navdate">navDate</a>
        /// </summary>
        /// <remarks>This can still be set manually</remarks>
        [JsonProperty(Order = 41)]
        public string? NavDate { get; set; }

        /// <summary>
        /// A single Canvas that provides additional content for use before the main content.
        /// See <a href="https://iiif.io/api/presentation/3.0/#placeholdercanvas">placeholdercanvas</a>
        /// </summary>
        [JsonProperty(Order = 51)]
        public Canvas? PlaceholderCanvas { get; set; }
        
        /// <summary>
        /// A single Canvas that provides additional content for use while rendering the resource.
        /// See <a href="https://iiif.io/api/presentation/3.0/#accompanyingcanvas">accompanyingcanvas</a>
        /// </summary>
        [JsonProperty(Order = 52)]
        public Canvas? AccompanyingCanvas { get; set; }
    
        [JsonProperty(Order = 900)]
        public List<AnnotationPage>? Annotations { get; set; }
    }
}
