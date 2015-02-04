﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public abstract class ResourcesBaseCmdlet : AzurePSCmdlet
    {
        private ResourcesClient resourcesClient;

        private GalleryTemplatesClient galleryTemplatesClient;

        private AuthorizationClient policiesClient;

        public ResourcesClient ResourcesClient
        {
            get
            {
                if (resourcesClient == null)
                {
                    resourcesClient = new ResourcesClient(Profile.Context)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return resourcesClient;
            }

            set { resourcesClient = value; }
        }

        public GalleryTemplatesClient GalleryTemplatesClient
        {
            get
            {
                if (galleryTemplatesClient == null)
                {
                    galleryTemplatesClient = new GalleryTemplatesClient(Profile.Context);
                }
                return galleryTemplatesClient;
            }

            set { galleryTemplatesClient = value; }
        }

        public AuthorizationClient PoliciesClient
        {
            get
            {
                if (policiesClient == null)
                {
                    policiesClient = new AuthorizationClient(Profile.Context);
                }
                return policiesClient;
            }

            set { policiesClient = value; }
        }
    }
}
