﻿using System;
using Android.Runtime;
using Android.App;
using Android.Content;
using Android.Support.V4.Content;

[assembly: UsesPermission("android.permission.ACCESS_NETWORK_STATE")]
[assembly: UsesPermission("android.permission.INTERNET")]
[assembly: UsesPermission("android.permission.WAKE_LOCK")]
[assembly: Permission(Name = "${applicationId}.permission.C2D_MESSAGE", ProtectionLevel = Android.Content.PM.Protection.Signature)]
[assembly: UsesPermission("com.google.android.c2dm.permission.RECEIVE")]

[assembly: UsesPermission("android.permission.RECEIVE_BOOT_COMPLETED")]
[assembly: MetaData("com.pushwoosh.plugin.location", Value = "com.pushwoosh.location.LocationPlugin")]

//BADGES
[assembly: MetaData("com.pushwoosh.plugin.badge", Value = "com.pushwoosh.badge.BadgePlugin")]
//samsung
[assembly: UsesPermission("com.sec.android.provider.badge.permission.READ")]
[assembly: UsesPermission("com.sec.android.provider.badge.permission.WRITE")]
//htc
[assembly: UsesPermission("com.htc.launcher.permission.READ_SETTINGS")]
[assembly: UsesPermission("com.htc.launcher.permission.UPDATE_SHORTCUT")]
//sony
[assembly: UsesPermission("com.sonyericsson.home.permission.BROADCAST_BADGE")]
[assembly: UsesPermission("com.sonymobile.home.permission.PROVIDER_INSERT_BADGE")]
//apex
[assembly: UsesPermission("com.anddoes.launcher.permission.UPDATE_COUNT")]
//solid
[assembly: UsesPermission("com.majeur.launcher.permission.UPDATE_BADGE")]
//huawei
[assembly: UsesPermission("com.huawei.android.launcher.permission.CHANGE_BADGE")]
[assembly: UsesPermission("com.huawei.android.launcher.permission.READ_SETTINGS")]
[assembly: UsesPermission("com.huawei.android.launcher.permission.WRITE_SETTINGS")]
//ZUK
[assembly: UsesPermission("android.permission.READ_APP_BADGE")]
//OPPO
[assembly: UsesPermission("com.oppo.launcher.permission.READ_SETTINGS")]
[assembly: UsesPermission("com.oppo.launcher.permission.WRITE_SETTINGS")]
//EvMe
[assembly: UsesPermission("me.everything.badger.permission.BADGE_COUNT_READ")]
[assembly: UsesPermission("me.everything.badger.permission.BADGE_COUNT_WRITE")]

namespace Pushwoosh.InApp
{
    [Preserve]
    [Service(Name = "com.pushwoosh.inapp.InAppRetrieverService", Permission = "android.permission.BIND_JOB_SERVICE")]
    partial class InAppRetrieverService { }
}

namespace Pushwoosh.InApp.View
{
    [Preserve]
    [Activity(Name = "com.pushwoosh.inapp.view.RichMediaWebActivity", Theme = "@android:style/Theme.Translucent.NoTitleBar")]
    partial class RichMediaWebActivity { }

    [Preserve]
    [Activity(Name = "com.pushwoosh.inapp.view.RemoteUrlActivity", Theme = "@android:style/Theme.Translucent.NoTitleBar")]
    partial class RemoteUrlActivity { }
}

namespace Pushwoosh
{
    [Preserve]
    [BroadcastReceiver(Name = "com.pushwoosh.BootReceiver", Enabled = true, Permission = "android.permission.RECEIVE_BOOT_COMPLETED")]
    [IntentFilter(new[] { "android.intent.action.BOOT_COMPLETED" }, Categories = new[] { "android.intent.category.DEFAULT" })]
    partial class BootReceiver { }

    [Preserve]
    [Service(Name = "com.pushwoosh.PushGcmIntentService", Exported = false)]
    [IntentFilter(new[] { "com.google.android.c2dm.intent.RECEIVE" }, Priority = -50)]
    partial class PushGcmIntentService { }

    [Preserve]
    [Service(Name = "com.pushwoosh.GcmRegistrationService", Exported = false)]
    [IntentFilter(new[] { "com.google.android.gms.iid.InstanceID" }, Priority = -50)]
    partial class GcmRegistrationService { }

    [Preserve]
    [ContentProvider(new[] { "${applicationId}.pushwooshinitprovider" }, Name = "com.pushwoosh.PushwooshInitProvider", Enabled = true, Exported = false, InitOrder = 50)]
    partial class PushwooshInitProvider { }

    [Preserve]
    [Service(Name = "com.pushwoosh.PushwooshService", Exported = false, Permission = "android.permission.BIND_JOB_SERVICE")]
    partial class PushwooshService {}

    [Preserve]
    [BroadcastReceiver(Name = "com.pushwoosh.NotificationOpenReceiver", Enabled = true, Exported = false)]
    partial class NotificationOpenReceiver {}
}

namespace Pushwoosh.GCM
{
    [Preserve]
    [BroadcastReceiver(Name = "com.google.android.gms.gcm.GcmReceiver", Exported = true, Permission = "com.google.android.c2dm.permission.SEND")]
    [IntentFilter(new[] { "com.google.android.c2dm.intent.RECEIVE", "com.google.android.c2dm.intent.REGISTRATION" }, Categories = new[] { "${applicationId}" })]
    [Register("com/pushwoosh/gcm/FakeGcmReceiver", DoNotGenerateAcw = true)]
    public class GcmReceiver : Android.Gms.Gcm.GcmReceiver { } //Fake receiver just to add right receiver to manifset

    [Preserve]
    [ContentProvider(new[] { "${applicationId}.gcmpushwooshinitprovider" }, Name = "com.pushwoosh.gcm.GcmInitProvider", Enabled = true, Exported = false, InitOrder = 53)]
    partial class GcmInitProvider { }
}

namespace Pushwoosh.Internal.Utils
{
    [Preserve]
    [Activity(Name = "com.pushwoosh.internal.utils.PermissionActivity", Theme = "@android:style/Theme.Translucent.NoTitleBar")]
    partial class PermissionActivity { }

    [Preserve]
    [Service(Name = "com.pushwoosh.internal.utils.LockScreenService", Permission = "android.permission.BIND_JOB_SERVICE", Enabled = true, Exported = false)]
    partial class LockScreenService { }
}

namespace Pushwoosh.Notification
{
    [Preserve]
    [BroadcastReceiver(Name = "com.pushwoosh.notification.LocalNotificationReceiver")]
    partial class LocalNotificationReceiver { }
}

namespace Pushwoosh.Location.Network
{
    [Preserve]
    [Service(Name = "com.pushwoosh.location.network.GeoLocationServiceApi16")]
    partial class GeoLocationServiceApi16 {}

    [Preserve]
    [Service(Name = "com.pushwoosh.location.network.GeoLocationServiceApi21", Exported = true, Permission = "android.permission.BIND_JOB_SERVICE")]
    partial class GeoLocationServiceApi21 { }
}

namespace Pushwoosh.Location.Internal.Utils
{
    [Preserve]
    [Activity(Name = "com.pushwoosh.location.internal.utils.ResolutionActivity", Theme = "@android:style/Theme.Translucent.NoTitleBar")]
    partial class ResolutionActivity { }
}

namespace Pushwoosh.Location.Geofencer
{
    [Preserve]
    [BroadcastReceiver(Name = "com.pushwoosh.location.geofencer.GeofenceReceiver")]
    [IntentFilter(new[] { "${applicationId}.action.GEOFENCE" } )]
    partial class GeofenceReceiver { }
}