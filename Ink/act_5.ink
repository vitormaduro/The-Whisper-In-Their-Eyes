== Scene_14 ==
	~ currentScene = 14
	>> restore_nvl
	>> clear_all
	>> change_bg black
	ACT_5_TITLE # title
	>> clear_text
	>> sfx break_stuff
	-> stitch_1
= stitch_1
	~ currentStitch = 1
	ACT_5_1.1
	ACT_5_1.2
	ACT_5_1.3
	ACT_5_1.4
	ACT_5_1.5
	ACT_5_1.6
	ACT_5_1.7
	ACT_5_1.8
	ACT_5_1.9
	>> clear_text
	>> sfx break_stuff
	>> sfx man_grunt_anger
	-> stitch_2
= stitch_2
	~ currentStitch = 2
	ACT_5_2.1
	ACT_5_2.2
	ACT_5_2.3
	ACT_5_2.4 # n
	ACT_5_2.5
	ACT_5_2.6
	ACT_5_2.7
	ACT_5_2.8
	>> clear_text
	>> change_bg blood_cave
	-> stitch_3
= stitch_3
	~ currentStitch = 3
	ACT_5_3.1
	>> clear_text
	>> sfx thousand_whispers
	-> stitch_4
= stitch_4
	~ currentStitch = 4
	ACT_5_4.1
	>> clear_text
	>> sfx break_stuff
	-> stitch_5
= stitch_5
	~ currentStitch = 5
	ACT_5_5.1
	>> clear_text
	>> sfx woman_right_here
	-> stitch_6
= stitch_6
	~ currentStitch = 6
	ACT_5_6.1
	ACT_5_6.2
	>> clear_text
	>> sfx walk_down_stairs
	>> sfx man_grunt_anger
	>> sprite ronan home_injured middle
	-> stitch_7
= stitch_7
	~ currentStitch = 7
	ACT_5_7.1
	ACT_5_7.2
	ACT_5_7.3
	ACT_5_7.4
	ACT_5_7.5
	>> clear_text
	-> stitch_8
= stitch_8
	~ currentStitch = 8
	ACT_5_8.1
	>> clear_text
	>> sfx man_grunt_anger
	-> stitch_9
= stitch_9
	~ currentStitch = 9
	ACT_5_9.1
	>> clear_text
	>> sfx man_grunt_anger
	>> sfx run_down_stairs
	-> stitch_10
= stitch_10
	~ currentStitch = 10
	ACT_5_10.1
	ACT_5_10.2
	ACT_5_10.3 # n
	ACT_5_10.4
	ACT_5_10.5
	ACT_5_10.6
	ACT_5_10.7
	ACT_5_10.8
	>> clear_text
	>> sfx woman_here_here_left
	-> stitch_11
= stitch_11
	~ currentStitch = 11
	ACT_5_11.1
	>> clear_text
	>> sfx woman_here_here_right
	-> stitch_12
= stitch_12
	~ currentStitch = 12
	ACT_5_12.1
	ACT_5_12.2
	ACT_5_12.3
	ACT_5_12.4
	ACT_5_12.5
	ACT_5_12.6
	ACT_5_12.7
	ACT_5_12.8
	ACT_5_12.9
	>> clear_text
	>> sfx man_grunt_anger
	-> stitch_13
= stitch_13
	~ currentStitch = 13
	ACT_5_13.1
	>> clear_text
	>> sfx light_flicker
	-> stitch_14
= stitch_14
	~ currentStitch = 14
	ACT_5_14.1 # n
	ACT_5_14.2
	ACT_5_14.3
	ACT_5_14.4
	ACT_5_14.5
	>> clear_text
	>> ost_on croak
	>> sfx man_violent_cough
	-> stitch_15
= stitch_15
	~ currentStitch = 15
	ACT_5_15.1
	ACT_5_15.2
	ACT_5_15.3
	>> clear_text
	-> stitch_16
= stitch_16
	~ currentStitch = 16
	ACT_5_16.1
	ACT_5_16.2
	ACT_5_16.3
	ACT_5_16.4
	ACT_5_16.5
	>> clear_text
	>> screen_shake true
	>> screen_shake false
	>> sfx man_scream_echo
	-> stitch_17
= stitch_17
	~ currentStitch = 17
	ACT_5_17.1
	ACT_5_17.2
	ACT_5_17.3
	ACT_5_17.4 # n
	ACT_5_17.5
	ACT_5_17.6
	ACT_5_17.7
	ACT_5_17.8
	ACT_5_17.9
	ACT_5_17.10 # n
	ACT_5_17.11
	ACT_5_17.12
	ACT_5_17.13
	ACT_5_17.14
	>> clear_text
	-> stitch_18
= stitch_18
	~ currentStitch = 18
	ACT_5_18.1
	ACT_5_18.2
	ACT_5_18.3
	>> clear_text
	>> screen_shake true
	>> screen_shake false
	>> sfx man_cough
	-> stitch_19
= stitch_19
	~ currentStitch = 19
	ACT_5_19.1
	ACT_5_19.2
	ACT_5_19.3
	ACT_5_19.4
	ACT_5_19.5
	ACT_5_19.6
	ACT_5_19.7
	ACT_5_19.8
	ACT_5_19.9
	ACT_5_19.10
	ACT_5_19.11
	ACT_5_19.12
	ACT_5_19.13
	ACT_5_19.14
	ACT_5_19.15
	ACT_5_19.16
	ACT_5_19.17
	ACT_5_19.18
	>> clear_text
	>> screen_shake true
	>> screen_shake false
	>> sfx man_cough
	-> stitch_20
= stitch_20
	~ currentStitch = 20
	ACT_5_20.1
	ACT_5_20.2
	ACT_5_20.3
	ACT_5_20.4
	ACT_5_20.5
	ACT_5_20.6
	ACT_5_20.7
	>> clear_text
	>> change_bg black
	-> stitch_21
= stitch_21
	~ currentStitch = 21
	ACT_5_21.1 # center
	>> clear_text
	>> change_bg blood_cave
	>> sfx light_flicker
	>> sfx woman_here_left
	-> stitch_22
= stitch_22
	~ currentStitch = 22
	ACT_5_22.1 # n
	ACT_5_22.2
	ACT_5_22.3
	ACT_5_22.4
	ACT_5_22.5
	ACT_5_22.6
	ACT_5_22.7
	>> clear_text
	>> sfx man_grunt_anger
	>> sfx thousand_whispers
	-> stitch_23
= stitch_23
	~ currentStitch = 23
	ACT_5_23.1
	ACT_5_23.2
	ACT_5_23.3
	>> clear_text
	-> stitch_24
= stitch_24
	~ currentStitch = 24
	ACT_5_24.1
	ACT_5_24.2
	ACT_5_24.3
	ACT_5_24.4
	ACT_5_24.5
	ACT_5_24.6
	ACT_5_24.7
	>> clear_all
	>> ost_off
	>> change_bg black
	>> wait 2
	>> sfx door_creak
	>> wait 1
	>> change_bg bedroom1
	-> stitch_25
= stitch_25
	~ currentStitch = 25
	ACT_5_25.1
	ACT_5_25.2
	>> clear_text
	>> sfx heart_thump
	>> ost_on croak
	>> sfx heavy_breathing
	-> stitch_26
= stitch_26
	~ currentStitch = 26
	ACT_5_26.1
	ACT_5_26.2
	ACT_5_26.3
	ACT_5_26.4
	ACT_5_26.5
	ACT_5_26.6
	ACT_5_26.7
	ACT_5_26.8
	>> clear_text
	-> stitch_27
= stitch_27
	~ currentStitch = 27
	ACT_5_27.1
	>> clear_text
	>> sfx woman_here_left
	-> stitch_28
= stitch_28
	~ currentStitch = 28
	ACT_5_28.1
	ACT_5_28.2
	>> clear_text
	>> ost_off
	>> change_bg black
	>> wait 2
	>> sfx door_creak
	>> wait 1
	>> change_bg blood_cave
	-> stitch_29
= stitch_29
	~ currentStitch = 29
	ACT_5_29.1
	ACT_5_29.2 # n
	ACT_5_29.3 # n
	ACT_5_29.4
	>> clear_text
	-> stitch_30
= stitch_30
	~ currentStitch = 30
	ACT_5_30.1 # shake 
	ACT_5_30.2 # shake
	>> clear_text
	-> stitch_31
= stitch_31
	~ currentStitch = 31
	ACT_5_31.1
	>> change_bg black
	>> wait 2
	>> sfx door_creak
	>> wait 1
	-> stitch_32
= stitch_32
	~ currentStitch = 32
	ACT_5_32.1
	>> clear_text
	>> change_bg office
	-> stitch_33
= stitch_33
	~ currentStitch = 33
	ACT_5_33.1
	>> clear_text
	-> stitch_34
= stitch_34
	~ currentStitch = 34
	ACT_5_34.1
	ACT_5_34.2
	>> clear_text
	>> change_bg black
	>> sfx heavy_breathing
	>> wait 2
	>> change_bg office
	-> stitch_35
= stitch_35
	~ currentStitch = 35
	ACT_5_35.1
	>> clear_text
	-> stitch_36
= stitch_36
	~ currentStitch = 36
	ACT_5_36.1
	>> clear_text
	-> stitch_37
= stitch_37
	~ currentStitch = 37
	ACT_5_37.1
	ACT_5_37.2
	ACT_5_37.3
	ACT_5_37.4
	ACT_5_37.5
	ACT_5_37.6
	ACT_5_37.7
	ACT_5_37.8
	ACT_5_37.9
	ACT_5_37.10
	>> clear_text
	>> sfx heavy_breathing
	-> stitch_38
= stitch_38
	~ currentStitch = 38
	ACT_5_38.1
	ACT_5_38.2
	>> clear_text
	-> stitch_39
= stitch_39
	~ currentStitch = 39
	ACT_5_39.1
	ACT_5_39.2
	ACT_5_39.3
	ACT_5_39.4
	ACT_5_39.5
	ACT_5_39.6
	ACT_5_39.7
	ACT_5_39.8
	ACT_5_39.9
	ACT_5_39.10
	>> clear_text
	>> sfx heavy_breathing
	-> stitch_40
= stitch_40
	~ currentStitch = 40
	ACT_5_40.1
	ACT_5_40.2
	ACT_5_40.3
	ACT_5_40.4
	ACT_5_40.5
	>> clear_text
	>> sfx malevolent_woman
	>> change_bg red
	-> stitch_41
= stitch_41
	~ currentStitch = 41
	ACT_5_41.1  # black
	ACT_5_41.2  # black
	ACT_5_41.3  # black
	ACT_5_41.4  # black
	ACT_5_41.5  # black
	ACT_5_41.6  # black
	ACT_5_41.7  # black # n
	ACT_5_41.8  # black
	ACT_5_41.9  # black
	ACT_5_41.10 # black 
	ACT_5_41.11 # black 
	ACT_5_41.12 # black 
	>> clear_text
	-> stitch_42
= stitch_42
	~ currentStitch = 42
	ACT_5_42.1 # black 
	>> clear_text
	-> stitch_43
= stitch_43
	~ currentStitch = 43
	ACT_5_43.1 # black 
	ACT_5_43.2 # black 
	ACT_5_43.3 # black 
	ACT_5_43.4 # black 
	ACT_5_43.5 # black 
	ACT_5_43.6 # black 
	ACT_5_43.7 # black 
	ACT_5_43.8 # black 
	ACT_5_43.9 # black 
	>> clear_text
	>> sfx heavy_breathing
	-> stitch_44
= stitch_44
	~ currentStitch = 44
	ACT_5_44.1 # black 
	>> clear_text
	>> sfx heart_thump
	>> sfx heavy_breathing
	-> stitch_45
= stitch_45
	~ currentStitch = 45
	ACT_5_45.1 # black 
	>> clear_text
	>> sfx heart_thump
	>> sfx heavy_breathing
	-> stitch_46
= stitch_46
	~ currentStitch = 46
	ACT_5_46.1 # black 
	>> clear_text
	>> sfx heart_thump
	>> sfx heavy_breathing
	-> stitch_47
= stitch_47
	~ currentStitch = 47
	ACT_5_47.1 # black 
	>> clear_text
	>> change_bg office
	-> stitch_48
= stitch_48
	~ currentStitch = 48
	ACT_5_48.1
	ACT_5_48.2
	ACT_5_48.3
	ACT_5_48.4
	>> clear_text
	>> sfx woman_here_right
	>> change_bg black
	-> stitch_49
= stitch_49
	~ currentStitch = 49
	ACT_5_49.1
	>> clear_text
	>> sfx door_creak
	>> wait 1
	-> stitch_50
= stitch_50
	~ currentStitch = 50
	ACT_5_50.1
	>> clear_text
	>> change_bg living_room
	-> stitch_51
= stitch_51
	~ currentStitch = 51
	ACT_5_51.1
	>> clear_text
	>> sfx woman_here_left
	>> wait 1
	>> sfx woman_no_here_right
	>> wait 1
	>> sfx woman_no_here_left
	>> wait 1
	>> sfx woman_yes_here_left
	>> wait 1
	>> sfx woman_come_here_right
	>> wait 1
	>> sfx woman_not_supposed_left
	>> wait 1
	>> sfx man_painful_scream
	>> wait 1
	-> stitch_52
= stitch_52
	~ currentStitch = 52
	ACT_5_52.1
	ACT_5_52.2
	ACT_5_52.3
	ACT_5_52.4
	ACT_5_52.5
	ACT_5_52.6
	ACT_5_52.7
	ACT_5_52.8
	ACT_5_52.9
	ACT_5_52.10
	ACT_5_52.11
	ACT_5_52.12
	ACT_5_52.13
	ACT_5_52.14
	>> clear_text
	-> stitch_53
= stitch_53
	~ currentStitch = 53
	ACT_5_53.1
	ACT_5_53.2
	ACT_5_53.3
	ACT_5_53.4
	ACT_5_53.5
	ACT_5_53.6
	>> clear_text
	>> sfx man_cough
	-> stitch_54
= stitch_54
	~ currentStitch = 54
	ACT_5_54.1
	ACT_5_54.2
	ACT_5_54.3
	ACT_5_54.4
	>> clear_text
	>> sfx heavy_breathing
	-> stitch_55
= stitch_55
	~ currentStitch = 55
	ACT_5_55.1
	>> clear_text
	>> sfx heavy_breathing
	-> stitch_56
= stitch_56
	~ currentStitch = 56
	ACT_5_56.1
	>> clear_text
	>> sfx heavy_breathing
	-> stitch_57
= stitch_57
	~ currentStitch = 57
	ACT_5_57.1
	>> clear_text
	>> sfx heavy_breathing
	-> stitch_58
= stitch_58
	~ currentStitch = 58
	ACT_5_58.1
	>> clear_text
	>> sfx heavy_breathing
	-> stitch_59
= stitch_59
	~ currentStitch = 59
	ACT_5_59.1
	>> clear_text
	>> change_bg black
	>> sfx woman_door_left
	>> wait 1
	>> sfx woman_front_door_right
	>> wait 1
	>> sfx woman_can_escape_left
	>> wait 1
	>> sfx woman_just_escape_right
	>> wait 1
	-> stitch_60
= stitch_60
	~ currentStitch = 60
	ACT_5_60.1
	ACT_5_60.2
	>> clear_text
	>> change_bg black
	-> stitch_61
= stitch_61
	~ currentStitch = 61
	ACT_5_61.1
	>> clear_text
	>> sfx door_creak
	>> wait 1
	-> stitch_62
= stitch_62
	~ currentStitch = 62
	ACT_5_62.1
	>> clear_text
	>> sfx door_close
	-> stitch_63
= stitch_63
	~ currentStitch = 63
	ACT_5_63.1
	>> clear_text
	>> change_bg bedroom1
	-> stitch_64
= stitch_64
	~ currentStitch = 64
	ACT_5_64.1
	ACT_5_64.2
	ACT_5_64.3
	ACT_5_64.4
	>> clear_text
	>> sfx heavy_breathing
	>> wait 1
	>> sfx laughter
	-> stitch_65
= stitch_65
	~ currentStitch = 65
	ACT_5_65.1
	ACT_5_65.2
	ACT_5_65.3
	ACT_5_65.4 # n
	ACT_5_65.5
	ACT_5_65.6 # n
	ACT_5_65.7
	>> clear_text
	>> sfx laughter
	>> wait 1
	-> stitch_66
= stitch_66
	~ currentStitch = 66
	ACT_5_66.1
	ACT_5_66.2
	ACT_5_66.3
	ACT_5_66.4
	>> clear_text
	-> stitch_67
= stitch_67
	~ currentStitch = 67
	ACT_5_67.1
	ACT_5_67.2
	ACT_5_67.3
	ACT_5_67.4
	ACT_5_67.5
	ACT_5_67.6
	ACT_5_67.7
	ACT_5_67.8
	ACT_5_67.9
	ACT_5_67.10 # n
	ACT_5_67.11
	ACT_5_67.12
	ACT_5_67.13
	ACT_5_67.14
	ACT_5_67.15
	ACT_5_67.16
	ACT_5_67.17
	>> clear_text
	>> sfx woman_here_left
	>> wait 1
	-> stitch_68
= stitch_68
	~ currentStitch = 68
	ACT_5_68.1
	ACT_5_68.2
	ACT_5_68.3
	ACT_5_68.4
	ACT_5_68.5
	ACT_5_68.6
	>> clear_text
	>> sfx woman_here_right
	>> wait 1
	-> stitch_69
= stitch_69
	~ currentStitch = 69
	ACT_5_69.1
	>> clear_text
	>> sfx woman_here_left
	>> wait 1
	-> stitch_70
= stitch_70
	~ currentStitch = 70
	ACT_5_70.1
	>> clear_text
	>> sfx woman_here_both
	>> wait 1
	>> sfx man_scream_echo
	>> wait 1
	>> screen_shake true
	>> screen_shake false
	-> stitch_71
= stitch_71
	~ currentStitch = 71
	ACT_5_71.1  # shake
	ACT_5_71.2 
	ACT_5_71.3  # shake
	ACT_5_71.4  # shake
	ACT_5_71.5  # shake
	ACT_5_71.6  # shake
	ACT_5_71.7  # shake
	ACT_5_71.8  # shake
	ACT_5_71.9  # shake
	ACT_5_71.10 # shake
	ACT_5_71.11 # shake
	ACT_5_71.12 # shake
	ACT_5_71.13 # shake
	ACT_5_71.14 # shake
	ACT_5_71.15 # shake
	ACT_5_71.16 # shake
	ACT_5_71.17 # shake
	>> clear_text
	>> sfx laughter
	>> wait 1
	>> sfx malevolent_woman
	>> wait 1
	-> stitch_72
= stitch_72
	~ currentStitch = 72
	ACT_5_72.1
	ACT_5_72.2
	ACT_5_72.3
	ACT_5_72.4
	ACT_5_72.5
	ACT_5_72.6
	ACT_5_72.7
	ACT_5_72.8
	ACT_5_72.9
	ACT_5_72.10
	>> clear_text
	>> change_bg red
	>> sfx malevolent_woman
	-> stitch_73
= stitch_73
	~ currentStitch = 73
	ACT_5_73.1 # black # center
	>> clear_text
	>> change_bg bedroom1
	-> stitch_74
= stitch_74
	~ currentStitch = 74
	ACT_5_74.1
	ACT_5_74.2
	ACT_5_74.3
	ACT_5_74.4
	ACT_5_74.5
	>> clear_text
	>> sfx woman_above
	-> stitch_75
= stitch_75
	~ currentStitch = 75
	ACT_5_75.1
	>> clear_text
	>> change_bg black
	>> sfx malevolent_woman
	>> wait 1
	-> stitch_76
= stitch_76
	~ currentStitch = 76
	ACT_5_76.1
	ACT_5_76.2
	ACT_5_76.3
	ACT_5_76.4
	ACT_5_76.5
	ACT_5_76.6
	ACT_5_76.7
	ACT_5_76.8
	ACT_5_76.9
	ACT_5_76.10
	>> clear_text
	>> sfx thing_on_ceiling
	-> stitch_77
= stitch_77
	~ currentStitch = 77
	ACT_5_77.1
	ACT_5_77.2
	ACT_5_77.3
	ACT_5_77.4
	ACT_5_77.5
	ACT_5_77.6
	ACT_5_77.7
	ACT_5_77.8
	ACT_5_77.9
	ACT_5_77.10
	ACT_5_77.11
	ACT_5_77.12
	ACT_5_77.13
	ACT_5_77.14
	ACT_5_77.15
	ACT_5_77.16
	>> clear_text
	-> stitch_78
= stitch_78
	~ currentStitch = 78
	ACT_5_78.1
	ACT_5_78.2
	ACT_5_78.3
	>> clear_text
	-> stitch_79
= stitch_79
	~ currentStitch = 79
	ACT_5_79.1
	ACT_5_79.2
	>> clear_text
	>> sfx tongue_licking
	>> wait 1
	-> stitch_80
= stitch_80
	~ currentStitch = 80
	ACT_5_80.1
	ACT_5_80.2
	ACT_5_80.3
	ACT_5_80.4
	>> clear_text
	-> stitch_81
= stitch_81
	~ currentStitch = 81
	ACT_5_81.1
	>> clear_text
	-> stitch_82
= stitch_82
	~ currentStitch = 82
	ACT_5_82.1
	>> clear_text
	-> stitch_83
= stitch_83
	~ currentStitch = 83
	ACT_5_83.1
	>> clear_text
	-> stitch_84
= stitch_84
	~ currentStitch = 84
	ACT_5_84.1
	>> clear_text
	-> stitch_85
= stitch_85
	~ currentStitch = 85
	ACT_5_85.1
	>> clear_text
	-> stitch_86
= stitch_86
	~ currentStitch = 86
	ACT_5_86.1
	>> clear_text
	-> stitch_87
= stitch_87
	~ currentStitch = 87
	ACT_5_87.1
	>> clear_text
	>> start_flash_bg red black
	>> wait 2
	>> stop_flash_bg
	>> sfx ringing_noise
	>> wait 2
	>> sfx woman_shriek
	>> clear_all
-> Scene_15

== Scene_15 ==
	~ currentScene = 15
	>> clear_all
	>> change_bg black
	>> sprite ronan army_tired middle
	-> stitch_88
= stitch_88
	~ currentStitch = 88
	ACT_5_88.1
	ACT_5_88.2
	ACT_5_88.3
	ACT_5_88.4
	ACT_5_88.5
	ACT_5_88.6
	ACT_5_88.7
	ACT_5_88.8
	ACT_5_88.9
	ACT_5_88.10
	ACT_5_88.11
	ACT_5_88.12
	ACT_5_88.13
	ACT_5_88.14
	ACT_5_88.15
	ACT_5_88.16
	ACT_5_88.17
	>> clear_text
	-> stitch_89
= stitch_89
	~ currentStitch = 89
	ACT_5_89.1
	ACT_5_89.2
	ACT_5_89.3
	ACT_5_89.4
	ACT_5_89.5
	ACT_5_89.6
	ACT_5_89.7
	>> clear_text
	-> stitch_90
= stitch_90
	~ currentStitch = 90
	ACT_5_90.1
	ACT_5_90.2
	ACT_5_90.3
	ACT_5_90.4
	ACT_5_90.5
	>> clear_text
	-> stitch_91
= stitch_91
	~ currentStitch = 91
	ACT_5_91.1
	>> clear_text
	-> stitch_92
= stitch_92
	~ currentStitch = 92
	ACT_5_92.1
	ACT_5_92.2
	>> clear_all
-> Scene_16